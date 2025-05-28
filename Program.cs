using Microsoft.Extensions.DependencyInjection;
using Warehouse.UI;

namespace Warehouse
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            var services = new ServiceCollection();

            Startup startup = new Startup();
            startup.ConfigureServices(services);

            // Register MappingProfile
            services.AddAutoMapper(typeof(MappingProfile));

            // Register forms
            startup.ConfigureForms(services);

            using (var provider = services.BuildServiceProvider())
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(provider.GetRequiredService<LoginForm>());
            }
        }
    }
}
