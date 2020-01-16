using BL.API;
using BL.Services;
using DAL;
using DAL.IRepositories;
using DAL.Repositories;
using GalaSoft.MvvmLight.Ioc;
using LibraryProjectClient.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.IO;
using System.Windows;

namespace LibraryProjectClient
{
    public partial class App : Application
    {
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
            SimpleIoc.Default.Register<IBookStoreRepository, BookStoreRepository>();
            SimpleIoc.Default.Register<IBookStoreService, BookStoreService>();
            SetupNavigation();
            ConfigureLogger();
        }


        private void SetupNavigation()
        {
            var navigationService = new NavigationService();
            navigationService.Configure("Books", new Uri("./Pages/Books.xaml",UriKind.Relative));
            navigationService.Configure("Journals", new Uri("./Pages/Journals.xaml",UriKind.Relative));
            SimpleIoc.Default.Register<IModernNavigationService>(() => navigationService);
        }

        private void ConfigureLogger()
        {
            var log = new LoggerConfiguration().WriteTo.File("./LogFiles/log-file.txt").CreateLogger();
            SimpleIoc.Default.Register<ILogger>(() => log);
            var logger = SimpleIoc.Default.GetInstance<ILogger>();
        }
    }
}
