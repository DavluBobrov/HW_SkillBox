using Autofac;
using Module_12.Infrastucture.Commands;
using Module_12.Models;
using Module_12.Models.Clients;
using Module_12.Models.Dtos;
using Module_12.Models.Employees;
using Module_12.Models.Repositories;
using Module_12.Models.Services;
using Module_12.ViewModels.Base;
using Module_12.Views.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Module_12.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        private AddNewClientWindow addNewClientWindow;

        #region Departaments

        private ObservableCollection<Departament> _Departaments;

        public ObservableCollection<Departament> Departaments
        {
            get { return _Departaments; }
            set { Set(ref _Departaments, value); }
        }

        #endregion Departaments

        #region CLients

        private IClientService ClientService { get; set; }
        private ObservableCollection<ClientDto> _ClientDtos;
        public IEmployee SelectedEmployee { get => ClientService.AuthenticationEmployee; }

        public ObservableCollection<ClientDto> ClientDtos
        {
            get { return _ClientDtos; }
            set { Set(ref _ClientDtos, value); }
        }

        #endregion CLients

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

        #region Selected Departament

        private static Departament selectedDepartament;

        public Departament SelectedDepartament
        {
            get { return MainWindowViewModel.selectedDepartament; }
            set
            {
                Set(ref MainWindowViewModel.selectedDepartament, value);
            }
        }

        #endregion Selected Departament

        #region Selected Client

        private ClientDto _SelectedClient;

        public ClientDto SelectedClient
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

        //private Bank _bank;

        //public Bank Bank
        //{
        //    get { return _bank; }
        //    set { Set(ref _bank, value); }
        //}

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
            //Bank.SerialazeDataClients();
        }

        private bool CanSerialazeDataCommandExecute(object p) => true;

        #endregion SerialazeDataCommand

        #region OpenAddNewClientWindow

        public ICommand OpenAddNewClientWindowCommand { get; }        // Здесь живет сама команда

        private void OnOpenAddNewClientWindowCommandExecuted(object p)
        {
            if (SelectedEmployee is Manager && SelectedDepartament != null)
            {
                addNewClientWindow = new();
                addNewClientWindow.ShowDialog();
            }
        }

        private bool CanOpenAddNewClientWindowCommandExecute(object p) => true;

        #endregion OpenAddNewClientWindow

        #region AddNewClient

        public ICommand AddNewClientCommand { get; }        // Здесь живет сама команда

        private void OnAddNewClientCommandExecuted(object? p)
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
            else
            {
                if (PhoneAdd.Length != 10)
                {
                    errorMassege += "Поле Телефона должно сожержать 10 цифр!\n";
                    isCorrect = false;
                }
            }
            if (string.IsNullOrEmpty(NumberAdd))
            {
                errorMassege += "Поле Номера паспорта не заполнено!\n";
                isCorrect = false;
            }
            else
            {
                if (NumberAdd.Length != 6)
                {
                    errorMassege += "Поле Номера должно сожержать 6 цифр!\n";
                    isCorrect = false;
                }
            }
            if (string.IsNullOrEmpty(SeriesAdd))
            {
                errorMassege += "Поле Серии паспорта не заполнено!\n";
                isCorrect = false;
            }
            else
            {
                if (SeriesAdd.Length != 4)
                {
                    errorMassege += "Поле Серии должно сожержать 4 цифр!\n";
                    isCorrect = false;
                }
            }
            //if (string.IsNullOrEmpty(DepAdd))
            //{
            //    errorMassege += "Поле Департамента не заполнено!\n";
            //    isCorrect = false;
            //}

            if (!isCorrect)
                MessageBox.Show(errorMassege);
            else
            {
                RealClient addRC = new(LNameAdd,
                                       FNameAdd,
                                       PatrAdd,
                                       PhoneAdd,
                                       new(SeriesAdd, NumberAdd),
                                       SelectedDepartament.Name);
                SelectedDepartament.Clients.Add(new ClientDto()
                {
                    ID = addRC.ID,
                    LastName = addRC.LastName,
                    FirstName = addRC.FirstName,
                    Patronymic = addRC.Patronymic,
                    PhoneNumber = addRC.PhoneNumber,
                    PassportData = addRC.PassportData,
                    Departament = addRC.Departament
                });
                var Repo = App.Container.Resolve<ClientsRepo>();
                Repo.AddNewClient(addRC);
                MessageBox.Show("Новый клиент Добавлен");
            }
        }

        private bool CanAddNewClientCommandExecute(object p) => true;

        #endregion AddNewClient

        #endregion Commands

        public MainWindowViewModel(IClientService clientService)
        {
            ClientService = clientService;
            ClientDtos = new ObservableCollection<ClientDto>(ClientService.GetClients());
            Departaments = new ObservableCollection<Departament>(FillDepartaments(ClientDtos));

            #region Fill Employees

            //_bank = new Bank();
            //Employees = new ObservableCollection<Consultant> { new Consultant(), new Manager() };

            #endregion Fill Employees

            //_Departaments = Bank.M Departaments;

            #region Commands

            SerialazeDataCommand = new LambdaCommand(OnSerialazeDataCommandExecuted, CanSerialazeDataCommandExecute);
            OpenAddNewClientWindowCommand = new LambdaCommand(OnOpenAddNewClientWindowCommandExecuted, CanOpenAddNewClientWindowCommandExecute);
            AddNewClientCommand = new LambdaCommand(OnAddNewClientCommandExecuted, CanAddNewClientCommandExecute);

            #endregion Commands
        }

        private IEnumerable<Departament> FillDepartaments(ObservableCollection<ClientDto> clientDtos)
        {
            Dictionary<string, Departament> keyValuePairs = new();
            foreach (var item in clientDtos)
            {
                if (!keyValuePairs.ContainsKey(item.Departament))
                    keyValuePairs.Add(item.Departament, new Departament(item.Departament));
                keyValuePairs[item.Departament].Clients.Add(item);
            }
            return keyValuePairs.Values;
        }
    }
}