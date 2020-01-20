using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace LibraryProjectClient
{
    public class MessageService : IMessageService
    {
        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
