using Autofac;
using Module_12.ViewModels;
using System.Windows;

namespace Module_12.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthenticationView.xaml
    /// </summary>
    public partial class AuthenticationView : Window
    {
        public AuthenticationView()
        {
            InitializeComponent();
            this.DataContext = App.Container.Resolve<AuthenticationVM>();
        }
    }
}