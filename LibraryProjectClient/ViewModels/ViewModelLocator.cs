using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;

namespace LibraryProjectClient.ViewModels
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<BookCreateViewModel>();
            SimpleIoc.Default.Register<BookListViewModel>();
            SimpleIoc.Default.Register<JournalCreateViewModel>();
            SimpleIoc.Default.Register<JournalListViewModel>();
            SimpleIoc.Default.Register<GenreCreateViewModel>();
            SimpleIoc.Default.Register<PublisherCreateViewModel>();
            SimpleIoc.Default.Register<AuthorCreateViewModel>();

        }
        public MainViewModel Main => SimpleIoc.Default.GetInstance<MainViewModel>();
        public BookCreateViewModel BookCreate => SimpleIoc.Default.GetInstance<BookCreateViewModel>();
        public BookListViewModel BookList => SimpleIoc.Default.GetInstance<BookListViewModel>();
        public JournalCreateViewModel JournalCreate => SimpleIoc.Default.GetInstance<JournalCreateViewModel>();
        public JournalListViewModel JournalList => SimpleIoc.Default.GetInstance<JournalListViewModel>();
        public AuthorCreateViewModel AuthorCreate => SimpleIoc.Default.GetInstance<AuthorCreateViewModel>();
        public PublisherCreateViewModel PublisherCreate => SimpleIoc.Default.GetInstance<PublisherCreateViewModel>();
        public GenreCreateViewModel GenreCreate => SimpleIoc.Default.GetInstance<GenreCreateViewModel>();

    }
}
