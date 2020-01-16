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
        }
        public MainViewModel Main => SimpleIoc.Default.GetInstance<MainViewModel>();
        public BookCreateViewModel BookCreate => SimpleIoc.Default.GetInstance<BookCreateViewModel>();
        public BookListViewModel BookList => SimpleIoc.Default.GetInstance<BookListViewModel>();
    }
}
