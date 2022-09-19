using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Module_13
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Bank A = new Bank();
        public Client SelectedClient { get; set; }

        public ObservableCollection<int> IdClientsWithOpenAccount
        {
            get
            {
                var result = new ObservableCollection<int>();
                foreach (var item in A.Clients)
                {
                    if (item.NotDeposit.isOpen || item.Deposit.isOpen && item.ID != SelectedClient.ID)
                        result.Add(item.ID);
                }
                return result;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            Grid.ItemsSource = A.Clients;
        }

        private void Grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedClient = (sender as DataGrid).SelectedItem as Client;
            CheckedAccounts();
            RefreshButtons();
        }

        #region Стартовые кнопки

        private void OpenAccCombo_Click(object sender, RoutedEventArgs e)
        {
            HideButtons();
            TypeAccOpenComboBox.Visibility = Visibility.Visible;
        }

        private void CloseAccComboButton_Click(object sender, RoutedEventArgs e)
        {
            HideButtons();
            TypeAccRemoveComboBox.Visibility = Visibility.Visible;
        }

        private void TopUpAccComboButton_Click(object sender, RoutedEventArgs e)
        {
            HideButtons();
            TypeAccTopUpComboBox.Visibility = Visibility.Visible;
        }

        private void HideButtons()
        {
            OpenAccComboButton.Visibility = Visibility.Collapsed;
            CloseAccComboButton.Visibility = Visibility.Collapsed;
            TopUpAccComboButton.Visibility = Visibility.Collapsed;
        }

        #endregion Стартовые кнопки

        #region События выбора в комбобоксах

        private void TypeAccOpenComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            OPEN_ACC_Button.Visibility = Visibility.Visible;
        }

        private void TypeAccRemoveComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CLOSE_ACC_Button.Visibility = Visibility.Visible;
        }

        private void TypeAccTopUpComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TopUpAccTextBox.Visibility = Visibility.Visible;
            TOPUP_ACC_Button.Visibility = Visibility.Visible;
        }

        #endregion События выбора в комбобоксах

        #region Кнопки после выбора счетов

        private void OPEN_ACC_Click(object sender, RoutedEventArgs e)
        {
            switch (TypeAccOpenComboBox.SelectedItem.ToString())
            {
                case "Депозитный":
                    (Grid.SelectedItem as Client).Deposit.isOpen = true;
                    break;

                case "Недепозитный":
                    (Grid.SelectedItem as Client).NotDeposit.isOpen = true;
                    break;
            }
            TypeAccOpenComboBox.SelectedIndex = -1;
            TypeAccOpenComboBox.Visibility = Visibility.Collapsed;
            CheckedAccounts();
            RefreshButtons();
        }

        private void CLOSE_ACC_Button_Click(object sender, RoutedEventArgs e)
        {
            switch (TypeAccRemoveComboBox.SelectedItem.ToString())
            {
                case "Депозитный":
                    (Grid.SelectedItem as Client).Deposit.isOpen = false;
                    break;

                case "Недепозитный":
                    (Grid.SelectedItem as Client).NotDeposit.isOpen = false;
                    break;
            }
            TypeAccRemoveComboBox.SelectedIndex = -1;
            TypeAccRemoveComboBox.Visibility = Visibility.Collapsed;
            CheckedAccounts();
            RefreshButtons();
        }

        private void TOPUP_ACC_Button_Click(object sender, RoutedEventArgs e)
        {
            Funtic funtic = new(Convert.ToInt32(TopUpAccTextBox.Text));
            switch (TypeAccTopUpComboBox.SelectedItem.ToString())
            {
                case "Депозитный":
                    (Grid.SelectedItem as Client).Deposit.SetBablo(funtic);
                    break;

                case "Недепозитный":
                    (Grid.SelectedItem as Client).NotDeposit.SetBablo(funtic);
                    break;
            }
            TypeAccTopUpComboBox.SelectedIndex = -1;
            TypeAccTopUpComboBox.Visibility = Visibility.Collapsed;
            TopUpAccTextBox.Text = "";
            TopUpAccTextBox.Visibility = Visibility.Collapsed;
            CheckedAccounts();
            RefreshButtons();
        }

        #endregion Кнопки после выбора счетов

        #region Обновление формы

        private void UpdateAccounts()
        {
            FirstNameTextBox.Text = (Grid.SelectedItem as Client).FirstName;
            LastNameTextBox.Text = (Grid.SelectedItem as Client).LastName;
            DepAccTextBox.Text = (Grid.SelectedItem as Client).Deposit.Bablo.Money.ToString();
            NotDepAccTextBox.Text = (Grid.SelectedItem as Client).NotDeposit.Bablo.Money.ToString();
        }

        private void CheckedAccounts()
        {
            TypeAccOpenComboBox.Items.Clear();
            TypeAccRemoveComboBox.Items.Clear();
            TypeAccTopUpComboBox.Items.Clear();
            FromWhereAccComboBox.Items.Clear();
            if ((Grid.SelectedItem as Client).Deposit.isOpen)
            {
                DepAccTextBox.Visibility = Visibility.Visible;
                DepAccTextBlock.Visibility = Visibility.Visible;
                TypeAccRemoveComboBox.Items.Add("Депозитный");
                TypeAccTopUpComboBox.Items.Add("Депозитный");
                FromWhereAccComboBox.Items.Add("Депозитный");
            }
            else
            {
                DepAccTextBox.Visibility = Visibility.Collapsed;
                DepAccTextBlock.Visibility = Visibility.Collapsed;
                TypeAccOpenComboBox.Items.Add("Депозитный");
            }
            if ((Grid.SelectedItem as Client).NotDeposit.isOpen)
            {
                NotDepAccTextBox.Visibility = Visibility.Visible;
                NotDepAccTextBlock.Visibility = Visibility.Visible;
                TypeAccRemoveComboBox.Items.Add("Недепозитный");
                TypeAccTopUpComboBox.Items.Add("Недепозитный");
                FromWhereAccComboBox.Items.Add("Недепозитный");
            }
            else
            {
                NotDepAccTextBox.Visibility = Visibility.Collapsed;
                NotDepAccTextBlock.Visibility = Visibility.Collapsed;
                TypeAccOpenComboBox.Items.Add("Недепозитный");
            }
            TypeAccOpenComboBox.Visibility = (TypeAccOpenComboBox.Items.Count == 0) ? Visibility.Collapsed : Visibility.Visible;
        }

        private void RefreshButtons()
        {
            OpenAccComboButton.Visibility = (TypeAccOpenComboBox.Items.Count != 0) ? Visibility.Visible : Visibility.Collapsed;
            CloseAccComboButton.Visibility = (TypeAccRemoveComboBox.Items.Count != 0) ? Visibility.Visible : Visibility.Collapsed;
            TopUpAccComboButton.Visibility = (TypeAccRemoveComboBox.Items.Count != 0) ? Visibility.Visible : Visibility.Collapsed;
            TransferGroupBox.Visibility = (TypeAccRemoveComboBox.Items.Count != 0) ? Visibility.Visible : Visibility.Collapsed;
            TypeAccOpenComboBox.Visibility = Visibility.Collapsed;
            OPEN_ACC_Button.Visibility = Visibility.Collapsed;
            CLOSE_ACC_Button.Visibility = Visibility.Collapsed;
            TOPUP_ACC_Button.Visibility = Visibility.Collapsed;
            UpdateAccounts();
            StartStateTransferGroup();
        }

        #endregion Обновление формы

        #region Transfer

        private void StartStateTransferGroup()
        {
            foreach (var item in TransferGrid.Children)
            {
                switch (item)
                {
                    case TextBlock Tblock:
                        Tblock.Visibility = Visibility.Collapsed; break;
                    case TextBox Tbox:
                        Tbox.Visibility = Visibility.Collapsed; break;
                    case Button b:
                        b.Visibility = Visibility.Collapsed; break;
                    case ComboBox c:
                        c.Visibility = Visibility.Collapsed; break;
                    default:
                        break;
                }
            }
            StartTransferButton.Visibility = Visibility.Visible;
        }

        private void StartTransferButton_Click(object sender, RoutedEventArgs e)
        {
            (sender as Button).Visibility = Visibility.Collapsed;
            FromWhereAccComboBox.Visibility = Visibility.Visible;
            FromWhereAccTextBlock.Visibility = Visibility.Visible;
            Id_ComboBox.ItemsSource = IdClientsWithOpenAccount;
        }

        private void FromWhereAccComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            IdTextBlock.Visibility = Visibility.Visible;
            Id_ComboBox.Visibility = Visibility.Visible;
        }

        private void Id_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ToWhereAccComboBox.Visibility = Visibility.Visible;
            ToWhereAccTextBlock.Visibility = Visibility.Visible;
        }

        #endregion Transfer

        private void ToWhereAccComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private IEnumerable<string> GetListTypeAccOpen(int ID)
        {
            List<string> result = new List<string>();
            if (A[ID].Deposit.isOpen)
                result.Add("Депозитный");
            if (A[ID].NotDeposit.isOpen)
                result.Add("Недепозитный");
            return result;
        }

        private IEnumerable<string> GetListTypeAccNotOpen(int ID)
        {
            List<string> result = new List<string>();
            if (!A[ID].Deposit.isOpen)
                result.Add("Депозитный");
            if (!A[ID].NotDeposit.isOpen)
                result.Add("Недепозитный");
            return result;
        }
    }
}