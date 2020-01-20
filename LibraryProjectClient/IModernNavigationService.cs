using GalaSoft.MvvmLight.Views;

namespace LibraryProjectClient
{
    public interface IModernNavigationService : INavigationService
    {
        object Parameter { get; }
    }
}