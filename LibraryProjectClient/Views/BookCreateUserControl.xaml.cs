using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LibraryProjectClient.Views
{
    /// <summary>
    /// Interaction logic for BookCreateUserControl.xaml
    /// </summary>
    public partial class BookCreateUserControl : UserControl
    {

        public BookCreateUserControl()
        {
            InitializeComponent();
        }
        private void TextBox_PreviewDecimalTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsDecimalTextAllowed(e.Text);
        }

        private bool IsDecimalTextAllowed(string text)
        {
            //return !decimalRegex.IsMatch(text);
            throw new NotImplementedException();
        }

        private void TextBox_PreviewIntTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsIntTextAllowed(e.Text);
        }
        private bool IsIntTextAllowed(string text)
        {
            throw new NotImplementedException();
        }
    }
}
