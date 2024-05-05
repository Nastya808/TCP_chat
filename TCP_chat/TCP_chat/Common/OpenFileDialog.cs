using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCP_chat.Server;
using TCP_chat.Common;
using TCP_chat.Client;

namespace TCP_chat.Common
{
    public class MyOpenFileDialog
    {
        public string OpenFileDialogMethod()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = "c:\\",
                Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*",
                FilterIndex = 2,
                RestoreDirectory = true
            };

            string SendFileName = null;

            if (openFileDialog.ShowDialog() == true)
            {
                SendFileName = openFileDialog.FileName;
            }
            return SendFileName;
        }
    }
}
