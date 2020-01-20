using BL.API;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using LibraryProjectClient.Pages;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace LibraryProjectClient.ViewModels
{
    public class JournalListViewModel : ViewModelBase
    {
        private IBookStoreService _service;
        private ObservableCollection<Journal> journals;
        public virtual Journal ReceivedJournal { get; protected set; }
        public JournalListViewModel(IBookStoreService service)
        {
            _service = service; 
            Messenger.Default.Register<Journal>(this, OnMessage);
            GetJournals();
        }

        private void OnMessage(Journal newJournal)
        {
            Journals.Add(newJournal);
        }

        private async void GetJournals()
        {
            Journals = new ObservableCollection<Journal>(await _service.GetAllJournalsAsync());
        }

        public ObservableCollection<Journal> Journals { get => journals; set => Set(ref journals, value); }
    }
}
