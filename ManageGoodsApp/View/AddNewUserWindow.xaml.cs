using ManageGoodsApp.ViewModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace ManageGoodsApp.View
{
    /// <summary>
    /// Логика взаимодействия для AddNewUserWindow.xaml
    /// </summary>
    public partial class AddNewUserWindow : Window
    {
        public AddNewUserWindow()
        {
            InitializeComponent();
            DataContext = new DataManage();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext != null)
            { DataManage.UserPassword = ((PasswordBox)sender).Password; }
        }

        private void PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
