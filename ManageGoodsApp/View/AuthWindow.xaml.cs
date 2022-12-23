using ManageGoodsApp.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace ManageGoodsApp.View
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
            DataContext = new DataManage();
        }
        
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext != null)
            { DataManage.UserPassword = ((PasswordBox)sender).Password; }
        }
    }
}
