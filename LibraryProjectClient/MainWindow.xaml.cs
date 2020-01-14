using DAL;
using DAL.IRepositories;
using DAL.Repositories;
using GalaSoft.MvvmLight.Ioc;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LibraryProjectClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var rep = SimpleIoc.Default.GetInstance<IBookStoreRepository>();
            Author auth = rep.GetAuthorRepository.AddAuthor(new Author() { Name = "Asaf", PenName = "Simco" });
        }
    }
}
