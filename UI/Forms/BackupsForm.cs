using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Warehouse.UI.Forms
{
    public partial class BackupsForm : Form
    {
        public BackupsForm()
        {
            InitializeComponent();
        }

        private void BackupAllBtn_Click(object sender, EventArgs e)
        {
            string backupFolder = Path.Combine(Application.StartupPath, "Backups");
            Directory.CreateDirectory(backupFolder);

            string[] databases = { "AuthDb", "MediaDb", "MasterDb", "TransactionDb", "AuditDb" };
            foreach (string dbName in databases)
            {
                try
                {
                    var builder = new SqlConnectionStringBuilder(
                        ConfigurationManager.ConnectionStrings[$"{dbName}"].ConnectionString);
                    builder.InitialCatalog = "master";

                    using (SqlConnection conn = new SqlConnection(builder.ConnectionString))
                    {
                        conn.Open();

                        string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                        string fileName = $"{dbName}_{timestamp}.bak";
                        string fullPath = Path.Combine(backupFolder, fileName);

                        string sql = $"BACKUP DATABASE [{dbName}] TO DISK = '{fullPath}'";
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }

                    var files = Directory.GetFiles(backupFolder, $"{dbName}_*.bak")
                                         .OrderByDescending(f => f).ToList();
                    for (int i = 5; i < files.Count; i++)
                        File.Delete(files[i]);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при бэкапе базы {dbName}: {ex.Message}", "Ошибка",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            MessageBox.Show("Создание резервных копий завершено.", "Готово",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void RestoreBtn_Click(object sender, EventArgs e)
        {
            string dbName = comboBoxDatabases.SelectedItem as string;
            if (string.IsNullOrEmpty(dbName))
            {
                MessageBox.Show("Выберите базу данных для восстановления.", "Внимание",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.InitialDirectory = Path.Combine(Application.StartupPath, "Backups");
                dlg.Filter = "Backup files (*.bak)|*.bak";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    string backupFile = dlg.FileName;
                    try
                    {
                        var builder = new SqlConnectionStringBuilder(
                            ConfigurationManager.ConnectionStrings[$"{dbName}"].ConnectionString);
                        builder.InitialCatalog = "master";

                        using (SqlConnection conn = new SqlConnection(builder.ConnectionString))
                        {
                            conn.Open();
                            string sql = $@"
                        ALTER DATABASE [{dbName}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
                        RESTORE DATABASE [{dbName}] FROM DISK = '{backupFile}' WITH REPLACE;
                        ALTER DATABASE [{dbName}] SET MULTI_USER;";
                            using (SqlCommand cmd = new SqlCommand(sql, conn))
                            {
                                cmd.CommandTimeout = 0;
                                cmd.ExecuteNonQuery();
                            }
                        }

                        MessageBox.Show($"База {dbName} успешно восстановлена из {backupFile}.", "Готово",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при восстановлении базы {dbName}: {ex.Message}", "Ошибка",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BackupsForm_Load(object sender, EventArgs e)
        {
            comboBoxDatabases.Items.Clear();
            comboBoxDatabases.Items.AddRange(new[]
            {
                "AuthDb",
                "MasterDb",
                "TransactionDb",
                "AuditDb"
            });

            comboBoxDatabases.SelectedIndex = 0;
        }
    }
}
