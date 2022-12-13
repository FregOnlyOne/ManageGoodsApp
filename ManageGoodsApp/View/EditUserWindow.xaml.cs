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
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            { ((dynamic)this.DataContext).UserPassword = ((PasswordBox)sender).Password; }
        }

        private void PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
