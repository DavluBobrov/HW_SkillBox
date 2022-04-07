using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
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
//using Newtonsoft.Json;

namespace Block_10_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TelegramClient client;
        public MainWindow()
        {
            InitializeComponent();
            client = new TelegramClient(this);
            LogList.ItemsSource = client.MsLogCollect;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string mess = new TextRange(MessUpload.Document.ContentStart, MessUpload.Document.ContentEnd).Text;
            if (LogList.SelectedItem != null && !string.IsNullOrEmpty(mess))
            {
                MessageLog clientMes = (LogList.SelectedItem as MessageLog);
                client.SendMessege(clientMes.ChatID, mess, clientMes.Token, clientMes.UpdateClientMes.Message.MessageId);
            }
        }

        private void LogList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextBlock_ChatID.Text = (LogList.SelectedItem as MessageLog).ChatID.ToString();
        }


        private void SerialazeMessLog(object sender, RoutedEventArgs e)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            string jsonString = System.Text.Json.JsonSerializer.Serialize(LogList.ItemsSource, options: options);
            using (StreamWriter sw = new StreamWriter("MessLog.json", true))
            {
                sw.WriteLine(jsonString);
            }
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
