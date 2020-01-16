using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryProjectClient
{
    public interface IModernNavigationService : INavigationService
    {
        object Parameter { get; }
    }
}
