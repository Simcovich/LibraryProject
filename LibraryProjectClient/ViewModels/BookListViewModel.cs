using BL.API;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Shared.Models;
using System.Collections.ObjectModel;

namespace LibraryProjectClient.ViewModels
{
    public class BookListViewModel : ViewModelBase
    {
        private IBookService _service;
        private ObservableCollection<Book> books;

        public BookListViewModel(IBookService service)
        {
            _service = service;
            Messenger.Default.Register<Book>(this, OnMessage);
            GetBooks();
        }
        private void OnMessage(Book newBook)
        {
            Books.Add(newBook);
        }
        private async void GetBooks()
        {
            
            Books = new ObservableCollection<Book>(await _service.GetAllBooksAsync());
        }

        public ObservableCollection<Book> Books { get => books; set => Set(ref books, value); }
    }
}