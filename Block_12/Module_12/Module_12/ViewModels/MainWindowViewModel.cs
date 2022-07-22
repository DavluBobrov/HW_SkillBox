using Module_12.Infrastucture.Commands;
using Module_12.Models;
using Module_12.Models.Clients;
using Module_12.Models.Employees;
using Module_12.ViewModels.Base;
using Module_12.Views.Windows;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Module_12.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        #region Properties

        #region Employees

        private ObservableCollection<Consultant> _Employees;

        public ObservableCollection<Consultant> Employees
        {
            get { return _Employees; }
            set { Set(ref _Employees, value); }
        }

        #endregion Employees

        #region AddNewClient

        #region Client

        private Client _AddMewClient;

        public Client AddNewClient
        {
            get { return _AddMewClient; }
            set { Set(ref _AddMewClient, value); }
        }

        #endregion Client

        #region Departament

        private string _departamentName;

        public string DepartamentName
        {
            get { return _departamentName; }
            set { Set(ref _departamentName, value); }
        }

        #endregion Departament

        #endregion AddNewClient

        #region SelectedProp

        #region Selected Employee

        private Consultant _SelectedEmployee;

        public Consultant SelectedEmployee
        {
            get { return _SelectedEmployee; }
            set { Set(ref _SelectedEmployee, value); }
        }

        #endregion Selected Employee

        #region Selected Departament

        private Departament selectedDepartament;

        public Departament SelectedDepartament
        { get => selectedDepartament; set => Set(ref selectedDepartament, value); }

        #endregion Selected Departament

        #region Selected Client

        private Client _SelectedClient;

        public Client SelectedClient
        { get => _SelectedClient; set => Set(ref _SelectedClient, value); }

        #endregion Selected Client

        #endregion SelectedProp

        private ObservableCollection<Departament> _Departaments;

        public ObservableCollection<Departament> Departaments
        {
            get { return _Departaments; }
            set { Set(ref _Departaments, value); }
        }

        private Departament selectedDepartamentMap;

        public Departament SelectedDepartamentMap
        { get => selectedDepartamentMap; set => Set(ref selectedDepartamentMap, value); }

        private Bank _bank;

        public Bank Bank
        {
            get { return _bank; }
            set { Set(ref _bank, value); }
        }

        #endregion Properties

        #region Commands

        #region CloseApplicationCommand

        /// <summary>
        /// Команда закрытия приложения
        /// </summary>
        public ICommand CloseApplicationCommand { get; }        // Здесь живет сама команда

        /// <summary>
        /// Метод выполняется, когда выполняется команда
        /// </summary>
        private void OnCloseApplicationCommandExecuted(object p)
        {
            Application.Current.Shutdown();
        }

        /// <returns>Доступна для выполнения всегда, поэтому всегда позвращает true</returns>
        private bool CanCloseApplicationCommandExecute(object p) => true;

        #endregion CloseApplicationCommand

        #region SerialazeDataCommand

        public ICommand SerialazeDataCommand { get; }        // Здесь живет сама команда

        private void OnSerialazeDataCommandExecuted(object p)
        {
            Bank.SerialazeDataClients();
        }

        private bool CanSerialazeDataCommandExecute(object p) => true;

        #endregion SerialazeDataCommand

        #region OpenAddNewClientWindow

        public ICommand OpenAddNewClientWindowCommand { get; }        // Здесь живет сама команда

        private void OnOpenAddNewClientWindowCommandExecuted(object p)
        {
            if (SelectedEmployee is Manager)
            {
                AddNewClientWindow addNewClientWindow = new();
                addNewClientWindow.ShowDialog();
            }
        }

        private bool CanOpenAddNewClientWindowCommandExecute(object p) => true;

        #endregion OpenAddNewClientWindow

        #region OpenAddNewClientWindow

        public ICommand AddNewClientCommand { get; }        // Здесь живет сама команда

        private void OnAddNewClientCommandExecuted(object p)
        {
        }

        private bool CanAddNewClientCommandExecute(object p) => true;

        #endregion OpenAddNewClientWindow

        #endregion Commands

        public MainWindowViewModel()
        {
            #region Fill Employees

            _bank = new Bank();
            Employees = new ObservableCollection<Consultant> { new Consultant(Bank.GetClientsForConsiltant()), new Manager(Bank.GetClientsForManager()) };

            #endregion Fill Employees

            //_Departaments = Bank.Departaments;

            #region Commands

            SerialazeDataCommand = new LambdaCommand(OnSerialazeDataCommandExecuted, CanSerialazeDataCommandExecute);
            OpenAddNewClientWindowCommand = new LambdaCommand(OnOpenAddNewClientWindowCommandExecuted, CanOpenAddNewClientWindowCommandExecute);
            AddNewClientCommand = new LambdaCommand(OnAddNewClientCommandExecuted, CanAddNewClientCommandExecute);

            #endregion Commands
        }
    }
}