using BL.API;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Shared.Models;
using System.Windows.Input;

namespace LibraryProjectClient.ViewModels
{
    public class PublisherCreateViewModel : ViewModelBase
    {
        private IPublisherService _service;

        public PublisherCreateViewModel(IPublisherService service)
        {
            _service = service;
            AddPublisherCommand = new RelayCommand(AddPublisher);
        }

        public ICommand AddPublisherCommand { get; set; }
        public string Name { get; set; }

        private async void AddPublisher()
        {
            var publisher = new Publisher() { Name = Name };
            await _service.AddPublisherAsync(publisher);
            Name = "";
        }
    }
}