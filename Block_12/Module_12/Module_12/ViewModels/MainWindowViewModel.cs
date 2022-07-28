using Module_12.Infrastucture.Commands;
using Module_12.Models;
using Module_12.Models.Clients;
using Module_12.Models.Employees;
using Module_12.ViewModels.Base;
using Module_12.Views.Windows;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Module_12.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        private AddNewClientWindow addNewClientWindow;

        #region Properties

        #region Employees

        private ObservableCollection<Consultant> _Employees;

        public ObservableCollection<Consultant> Employees
        {
            get { return _Employees; }
            set { Set(ref _Employees, value); }
        }

        #endregion Employees

        #region SelectedProp

        #region Selected Employee

        private Consultant _SelectedEmployee;

        public Consultant SelectedEmployee
        {
            get { return _SelectedEmployee; }
            set
            {
                Set(ref _SelectedEmployee, value);
                if (_SelectedEmployee is Manager)
                {
                }
            }
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

        #region AddClientWindow

        #region FNameAdd

        private string _FNameAdd;

        public string FNameAdd
        {
            get { return _FNameAdd; }
            set { Set(ref _FNameAdd, value); }
        }

        #endregion FNameAdd

        #region LNameAdd

        private string _LNameAdd;

        public string LNameAdd
        {
            get { return _LNameAdd; }
            set { Set(ref _LNameAdd, value); }
        }

        #endregion LNameAdd

        #region PatrAdd

        private string _PatrAdd;

        public string PatrAdd
        {
            get { return _PatrAdd; }
            set { Set(ref _PatrAdd, value); }
        }

        #endregion PatrAdd

        #region PhoneAdd

        private string _PhoneAdd;

        public string PhoneAdd
        {
            get { return _PhoneAdd; }
            set { Set(ref _PhoneAdd, value); }
        }

        #endregion PhoneAdd

        #region SeriesAdd

        private string _SeriesAdd;

        public string SeriesAdd
        {
            get { return _SeriesAdd; }
            set { Set(ref _SeriesAdd, value); }
        }

        #endregion SeriesAdd

        #region NumberAdd

        private string _NumberAdd;

        public string NumberAdd
        {
            get { return _NumberAdd; }
            set { Set(ref _NumberAdd, value); }
        }

        #endregion NumberAdd

        #region DepAdd

        private string _DepAdd;

        public string DepAdd
        {
            get { return _DepAdd; }
            set { Set(ref _DepAdd, value); }
        }

        #endregion DepAdd

        #endregion AddClientWindow

        #region Bank

        private Bank _bank;

        public Bank Bank
        {
            get { return _bank; }
            set { Set(ref _bank, value); }
        }

        #endregion Bank

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
                addNewClientWindow = new();
                addNewClientWindow.Show();
            }
        }

        private bool CanOpenAddNewClientWindowCommandExecute(object p) => true;

        #endregion OpenAddNewClientWindow

        #region AddNewClient

        public ICommand AddNewClientCommand { get; }        // Здесь живет сама команда

        private void OnAddNewClientCommandExecuted(object p)
        {
            bool isCorrect = true;
            string errorMassege = string.Empty;
            if (string.IsNullOrEmpty(FNameAdd))
            {
                errorMassege += "Поле Имени не заполнено!\n";
                isCorrect = false;
            }
            if (string.IsNullOrEmpty(LNameAdd))
            {
                errorMassege += "Поле Фамилии не заполнено!\n";
                isCorrect = false;
            }
            if (string.IsNullOrEmpty(PatrAdd))
            {
                errorMassege += "Поле Отчества не заполнено!\n";
                isCorrect = false;
            }
            if (string.IsNullOrEmpty(PhoneAdd))
            {
                errorMassege += "Поле Номера Телефона не заполнено!\n";
                isCorrect = false;
            }
            if (string.IsNullOrEmpty(NumberAdd))
            {
                errorMassege += "Поле Номера паспорта не заполнено!\n";
                isCorrect = false;
            }
            else
            {
            }
            if (string.IsNullOrEmpty(SeriesAdd))
            {
                errorMassege += "Поле Серии паспорта не заполнено!\n";
                isCorrect = false;
            }
            if (string.IsNullOrEmpty(DepAdd))
            {
                errorMassege += "Поле Департамента не заполнено!\n";
                isCorrect = false;
            }
            if (!isCorrect)
                MessageBox.Show(errorMassege);
            else
            {
                if (!Bank.DepartamentMap.ContainsKey(AddDepartamentName))
                    Bank.DepartamentMap.Add(AddDepartamentName, new Departament(AddDepartamentName));
                Bank.DepartamentMap[AddDepartamentName].Clients
                    .Add(new RealClient(++Bank.MaxID,
                                        LNameAdd,
                                        FNameAdd,
                                        PatrAdd,
                                        PhoneAdd,
                                        new(SeriesAdd, NumberAdd)));
                MessageBox.Show("Новый клиент Добавлен");
            }
        }

        private bool CanAddNewClientCommandExecute(object p) => true;

        #endregion AddNewClient

        #endregion Commands

        public MainWindowViewModel()
        {
            #region Fill Employees

            _bank = new Bank();
            Employees = new ObservableCollection<Consultant> { new Consultant(), new Manager() };

            #endregion Fill Employees

            //_Departaments = Bank.M Departaments;

            #region Commands

            SerialazeDataCommand = new LambdaCommand(OnSerialazeDataCommandExecuted, CanSerialazeDataCommandExecute);
            OpenAddNewClientWindowCommand = new LambdaCommand(OnOpenAddNewClientWindowCommandExecuted, CanOpenAddNewClientWindowCommandExecute);
            AddNewClientCommand = new LambdaCommand(OnAddNewClientCommandExecuted, CanAddNewClientCommandExecute);

            #endregion Commands
        }
    }
}