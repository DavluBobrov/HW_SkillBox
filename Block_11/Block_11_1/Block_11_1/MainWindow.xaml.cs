using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Block_11_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static ObservableCollection<Client> CliesntList;

        public MainWindow()
        {
            InitializeComponent();
            CliesntList = new ObservableCollection<Client>();
            DaraView.ItemsSource = CliesntList;
            FillCollection();
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
        }

        private void FillCollection()
        {
            Random r = new Random();
            for (int i = 0; i < 10; i++)
            {
                CliesntList.Add(new Client(
                    $"lName{i}",
                    $"fName{i}",
                    $"Patronymic{i}",
                    $"+79{r.Next(10000000, 100000000)}",
                    new Passport($"{r.Next(1000, 10000)}", $"{r.Next(100000, 1000000)}")));
            }
        }
    }
}