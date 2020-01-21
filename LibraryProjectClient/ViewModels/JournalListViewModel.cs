using BL.API;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Shared.Models;
using System;
using System.Collections.ObjectModel;

namespace LibraryProjectClient.ViewModels
{
    public class JournalListViewModel : ViewModelBase
    {
        private IJournalService _service;
        private ObservableCollection<Journal> journals;
        public virtual Journal ReceivedJournal { get; protected set; }

        public JournalListViewModel(IJournalService service)
        {
            _service = service;
            Messenger.Default.Register<Journal>(this, OnMessage);
            Messenger.Default.Register<AbstractDiscount>(this, onDiscount);
            GetJournals();
        }

        private async void onDiscount(AbstractDiscount obj)
        {
            Journals = new ObservableCollection<Journal>(await _service.GetAllJournalsAsync());
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