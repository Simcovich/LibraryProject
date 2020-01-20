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
    public class GenreCreateViewModel : ViewModelBase
    {
        IBookStoreService _service;
        public GenreCreateViewModel(IBookStoreService service)
        {
            _service = service;
            AddGenreCommand = new RelayCommand(AddGenre);
        }
        public ICommand AddGenreCommand { get; set; }
        public string Name { get; set; }
        private async void AddGenre()
        {
            var genre = new Genre() { Name = Name };
            await _service.AddGenreAsync(genre);
            Name = "";
        }
    }
}
