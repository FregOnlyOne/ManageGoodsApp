using ManageGoodsApp.ViewModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using ManageGoodsApp.Model;

namespace ManageGoodsApp.View
{
    /// <summary>
    /// Логика взаимодействия для EditUserWindow.xaml
    /// </summary>
    public partial class EditUserWindow : Window
    {
        public EditUserWindow(User userToEdit)
        {
            InitializeComponent();
            DataContext = new DataManage();
            DataManage.SelectedUser = userToEdit;
            DataManage.UserName = userToEdit.Name;
            DataManage.UserSurname = userToEdit.Surname;
            DataManage.UserPatronymic = userToEdit.Patronymic;
            DataManage.UserEmail = userToEdit.Email;
            DataManage.UserPhone = userToEdit.Phone;
            DataManage.UserLogin = userToEdit.Login;
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext != null)
            { DataManage.UserPassword = ((PasswordBox)sender).Password; }
        }

        private void PreviewPhoneTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = Regex.IsMatch(e.Text, "[^0-9^(^)^+^-]+");
        }
    }
}
