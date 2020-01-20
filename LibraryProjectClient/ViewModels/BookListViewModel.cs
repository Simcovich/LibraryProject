using BL.API;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace LibraryProjectClient.ViewModels
{
    public class BookListViewModel : ViewModelBase
    {
        private IBookStoreService _service;
        private ObservableCollection<Book> books;

        public BookListViewModel(IBookStoreService service)
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
        public ObservableCollection<Book> Books { get => books; set=>Set(ref books,  value); }
    }
}
