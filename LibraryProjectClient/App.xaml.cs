using BL.API;
using BL.Services;
using DAL;
using DAL.IRepositories;
using DAL.Repositories;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
            SimpleIoc.Default.Register<IBookRepository, BookRepository>();
            SimpleIoc.Default.Register<IAuthorRepository, AuthorRepository>();
            SimpleIoc.Default.Register<IGenreRepository, GenreRepository>();
            SimpleIoc.Default.Register<IAbstractItemRepository, AbstractItemRepository>();
            SimpleIoc.Default.Register<IDiscountRepository, DiscountRepository>();
            SimpleIoc.Default.Register<IPublisherRepository, PublisherReposiory>();
            SimpleIoc.Default.Register<IJournalRepository, JournalRepository>();
            SimpleIoc.Default.Register<IBookService, BookService>();
            SimpleIoc.Default.Register<IAuthorService, AuthorService>();
            SimpleIoc.Default.Register<IGenreService, GenreService>();
            SimpleIoc.Default.Register<ISearchService, SearchService>();
            SimpleIoc.Default.Register<IDiscountService, DiscountService>();
            SimpleIoc.Default.Register<IPublisherService, PublisherService>();
            SimpleIoc.Default.Register<IJournalService, JournalService>();
            SimpleIoc.Default.Register<IMessageService, MessageService>();
            SimpleIoc.Default.Register<IDiscountRepository, DiscountRepository>();
            SetupNavigation();
            ConfigureLogger();
        }

        private void SetupNavigation()
        {
            var navigationService = new NavigationService();
            navigationService.Configure("Books", new Uri("./Pages/Books.xaml", UriKind.Relative));
            navigationService.Configure("Journals", new Uri("./Pages/Journals.xaml", UriKind.Relative));
            navigationService.Configure("AddPublisher", new Uri("./Pages/AddPublisher.xaml", UriKind.Relative));
            navigationService.Configure("AddGenre", new Uri("./Pages/AddGenre.xaml", UriKind.Relative));
            navigationService.Configure("AddAuthor", new Uri("./Pages/AddAuthor.xaml", UriKind.Relative));
            navigationService.Configure("AddBook", new Uri("./Pages/AddBook.xaml", UriKind.Relative));
            navigationService.Configure("AddJournal", new Uri("./Pages/AddJournal.xaml", UriKind.Relative));
            navigationService.Configure("AddDiscount", new Uri("./Pages/AddDiscount.xaml", UriKind.Relative));
            navigationService.Configure("SearchPage", new Uri("./Pages/SearchPage.xaml", UriKind.Relative));
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