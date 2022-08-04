using Autofac;
using Module_12.ViewModels;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Module_12.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddNewClientWindow.xaml
    /// </summary>
    public partial class AddNewClientWindow : Window
    {
        public AddNewClientWindow()
        {
            InitializeComponent();
            this.DataContext = App.Container.Resolve<MainWindowViewModel>();
        }

        #region Приколы с правильным вводом

        private void OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !e.Text.All(IsGood);
        }

        private void OnPasting(object sender, DataObjectPastingEventArgs e)
        {
            var stringData = (string)e.DataObject.GetData(typeof(string));
            if (stringData == null || !stringData.All(IsGood))
                e.CancelCommand();
        }

        private bool IsGood(char c)
        {
            if (c >= '0' && c <= '9')
                return true;
            return false;
        }

        #endregion Приколы с правильным вводом
    }
}