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
            (TypeAccOpenComboBox.SelectedItem as IAccount<Funtic>).isOpen = true;
            TypeAccOpenComboBox.SelectedIndex = -1;
            TypeAccOpenComboBox.Visibility = Visibility.Collapsed;
            CheckedAccounts();
            RefreshButtons();
        }

        private void CLOSE_ACC_Button_Click(object sender, RoutedEventArgs e)
        {
            (TypeAccRemoveComboBox.SelectedItem as IAccount<Funtic>).isOpen = false;
            TypeAccRemoveComboBox.SelectedIndex = -1;
            TypeAccRemoveComboBox.Visibility = Visibility.Collapsed;
            CheckedAccounts();
            RefreshButtons();
        }

        private void TOPUP_ACC_Button_Click(object sender, RoutedEventArgs e)
        {
            Funtic funtic = new(Convert.ToInt32(TopUpAccTextBox.Text));

            (TypeAccTopUpComboBox.SelectedItem as IAccount<Funtic>).SetBablo(funtic);
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
            TypeAccOpenComboBox.ItemsSource = GetListTypeAccNotOpen(SelectedClient.ID);
            TypeAccRemoveComboBox.ItemsSource = GetListTypeAccOpen(SelectedClient.ID);
            TypeAccTopUpComboBox.ItemsSource = GetListTypeAccOpen(SelectedClient.ID);
            FromWhereAccComboBox.ItemsSource = GetListTypeAccOpen(SelectedClient.ID);
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
            ToWhereAccComboBox.ItemsSource = GetListTypeAccOpen(int.Parse((sender as ComboBox).SelectedItem.ToString()));
        }

        private void ToWhereAccComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TransferTextBlock.Visibility = Visibility.Visible;
            AmountToTransfer.Visibility = Visibility.Visible;
            TransferButton.Visibility = Visibility.Visible;
        }

        private void TransferButton_Click(object sender, RoutedEventArgs e)
        {
            int funtic = Convert.ToInt32(AmountToTransfer.Text);
            int ID = int.Parse(Id_ComboBox.SelectedItem.ToString());
            (ToWhereAccComboBox.SelectedItem as IAccount<Funtic>)
                .SetBablo((FromWhereAccComboBox.SelectedItem as IAccount<Funtic>)
                .GetBablo(funtic));
            StartStateTransferGroup();
            UpdateAccounts();
        }

        #endregion Transfer

        #region MetodsFor ComboBox.ItemSorce

        private IEnumerable<IAccount<Funtic>> GetListTypeAccOpen(int ID)
        {
            List<IAccount<Funtic>> result = new();
            if (A[ID].Deposit.isOpen)
                result.Add(A[ID].Deposit);
            if (A[ID].NotDeposit.isOpen)
                result.Add(A[ID].NotDeposit);
            return result;
        }

        private IEnumerable<IAccount<Funtic>> GetListTypeAccNotOpen(int ID)
        {
            List<IAccount<Funtic>> result = new();
            if (!A[ID].Deposit.isOpen)
                result.Add(A[ID].Deposit);
            if (!A[ID].NotDeposit.isOpen)
                result.Add(A[ID].NotDeposit);
            return result;
        }

        #endregion MetodsFor ComboBox.ItemSorce
    }
}