using BL.API;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Shared.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

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
            Messenger.Default.Register<AbstractDiscount>(this, onDiscount);
            GetBooks();
        }
        private async void onDiscount(AbstractDiscount obj)
        {
            Books = new ObservableCollection<Book>(await _service.GetAllBooksAsync());
        }
        private void OnMessage(Book newBook)
        {
            Books.Add(newBook);
        }
        private async void GetBooks()
        {
            var bookList = await _service.GetAllBooksAsync();
            Books = new ObservableCollection<Book>(bookList);
        }

        public ObservableCollection<Book> Books { get => books; set => Set(ref books, value); }
    }
}