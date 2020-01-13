using DAL;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Windows;

namespace LibraryProjectClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; private set; }
        public IConfiguration Configuration { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            var builder = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();
            ConfigureServices();
        }

        private void ConfigureServices()
        {
            SimpleIoc.Default.Register(() =>
            {
                var builder = new DbContextOptionsBuilder<BookStoreContext>();
                builder.UseSqlServer(Configuration.GetConnectionString("SqlConnection"));
                return new BookStoreContext(builder.Options);
            });
        }
    }
}
