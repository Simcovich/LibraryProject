using BL.API;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace LibraryProjectClient.ViewModels
{
    public class SearchViewModel : ViewModelBase
    {
        ISearchService _searchService;
        private ObservableCollection<AbstractItem> items;

        public SearchViewModel(ISearchService searchService)
        {
            _searchService = searchService;
            Search = new RelayCommand(SearchItems);
        }

        public ObservableCollection<AbstractItem> Items { get => items; set => Set(ref items ,value); }
        public ICommand Search { get; set; }
        public string Title { get; set; }
        private async void SearchItems()
        {
            Items = new ObservableCollection<AbstractItem>(await _searchService.SearchItemsByTitle(Title));
        }
    }
}
