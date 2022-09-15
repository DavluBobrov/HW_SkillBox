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

namespace Module_13
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Bank A = new Bank();
        public Client SelectedClient { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Grid.ItemsSource = A.Clients;
        }

        private void Grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FirstNameTextBox.Text = (Grid.SelectedItem as Client).FirstName;
            LastNameTextBox.Text = (Grid.SelectedItem as Client).LastName;
            CheckedAccounts();
            DepAccTextBox.Text = (Grid.SelectedItem as Client).Deposit.Bablo.Money.ToString();
            NotDepAccTextBox.Text = (Grid.SelectedItem as Client).NotDeposit.Bablo.Money.ToString();
            RefreshButtons();
        }

        private void CheckedAccounts()
        {
            if ((Grid.SelectedItem as Client).Deposit.isOpen)
            {
                DepAccTextBox.Visibility = Visibility.Visible;
                DepAccTextBlock.Visibility = Visibility.Visible;
            }
            else
            {
                DepAccTextBox.Visibility = Visibility.Collapsed;
                DepAccTextBlock.Visibility = Visibility.Collapsed;
            }
            if ((Grid.SelectedItem as Client).NotDeposit.isOpen)
            {
                NotDepAccTextBox.Visibility = Visibility.Visible;
                NotDepAccTextBlock.Visibility = Visibility.Visible;
            }
            else
            {
                NotDepAccTextBox.Visibility = Visibility.Collapsed;
                NotDepAccTextBlock.Visibility = Visibility.Collapsed;
            }
        }

        private void OpenAccCombo_Click(object sender, RoutedEventArgs e)
        {
            OpenAccComboButton.Visibility = Visibility.Collapsed;
            TypeAccComboBox.Visibility = Visibility.Visible;
        }

        private void TypeAccComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            OPEN_ACC_Button.Visibility = Visibility.Visible;
        }

        private void OPEN_ACC_Click(object sender, RoutedEventArgs e)
        {
            switch (TypeAccComboBox.SelectedIndex)
            {
                case 0:
                    (Grid.SelectedItem as Client).Deposit.isOpen = true;
                    break;

                case 1:
                    (Grid.SelectedItem as Client).NotDeposit.isOpen = true;
                    break;
            }
            TypeAccComboBox.SelectedIndex = -1;
            CheckedAccounts();
            RefreshButtons();
        }

        private void RefreshButtons()
        {
            OpenAccComboButton.Visibility = Visibility.Visible;
            TypeAccComboBox.Visibility = Visibility.Collapsed;
            OPEN_ACC_Button.Visibility = Visibility.Collapsed;
            OPEN_ACC_Button.UpdateLayout();
        }
    }
}