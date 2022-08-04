using Module_12.Infrastucture.Commands;
using Module_12.Models.Employees;
using Module_12.Models.Services;
using Module_12.ViewModels.Base;
using Module_12.Views.Windows;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace Module_12.ViewModels
{
    internal class AuthenticationVM : ViewModel
    {
        public AuthenticationVM(
            IAuthenticationService authenticationService)
        {
            AuthenticationService = authenticationService;
            AuthenticateCommand = new LambdaCommand(Authenticate);
            EmployeesCollection = new ObservableCollection<IEmployee>(authenticationService.GetAll());
        }

        public LambdaCommand AuthenticateCommand { get; }
        public ObservableCollection<IEmployee> EmployeesCollection { get; }
        public IEmployee SelectedEmployee { get; set; }
        private IAuthenticationService AuthenticationService { get; }

        public void Authenticate(object parameter)
        {
            try
            {
                AuthenticationService.Authenticate(SelectedEmployee);
                OpenClientsView();
                CloseThisView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CloseThisView()
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window is AuthenticationView)
                {
                    window.Close();
                    break;
                }
            }
        }

        private void OpenClientsView()
        {
            var window = new MainWindow();
            window.Show();
        }
    }
}