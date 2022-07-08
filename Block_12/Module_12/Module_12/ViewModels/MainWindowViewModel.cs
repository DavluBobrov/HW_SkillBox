using Module_12.Models;
using Module_12.Models.Employees;
using Module_12.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Module_12.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        private ObservableCollection<Departament> _Departaments;

        public ObservableCollection<Departament> Departaments
        {
            get { return _Departaments; }
            set { Set(ref _Departaments, value); }
        }

        private System.Collections.IEnumerable selectedEmployee;

        public System.Collections.IEnumerable SelectedEmployee { get => selectedEmployee; set => Set(ref selectedEmployee, value); }

        private Bank _bank;

        public Bank Bank
        {
            get { return _bank; }
            set { Set(ref _bank, value); }
        }

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

        #region CloseApplicationCommand

        /// <summary>
        /// Команда закрытия приложения
        /// </summary>
        public ICommand SerialazeDataCommand { get; }        // Здесь живет сама команда

        /// <summary>
        /// Метод выполняется, когда выполняется команда
        /// </summary>
        private void OnSerialazeDataCommandExecuted(object p)
        {
            Bank.SerialazeDataClients();
        }

        /// <returns>Доступна для выполнения всегда, поэтому всегда позвращает true</returns>
        private bool CanSerialazeDataCommandExecute(object p) => true;

        #endregion CloseApplicationCommand

        public MainWindowViewModel()
        {
            _bank = new Bank();
            _Departaments = Bank._Departaments;
        }
    }
}