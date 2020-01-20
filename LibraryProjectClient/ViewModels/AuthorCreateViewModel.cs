using BL.API;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace LibraryProjectClient.ViewModels
{
    public class AuthorCreateViewModel: ViewModelBase
    {
        IBookStoreService _service;
        public AuthorCreateViewModel(IBookStoreService service)
        {
            _service = service;
            AddAuthorCommand = new RelayCommand(AddAuthor);
        }
        public ICommand AddAuthorCommand { get; set; }
        public string Name { get; set; }
        public string PenName { get; set; }
        private async void AddAuthor()
        {
            var author = new Author() { Name = Name, PenName=PenName };
            await _service.AddAuthorAsync(author);
            Name = "";
        }
    }
}
