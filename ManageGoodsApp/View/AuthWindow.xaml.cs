using ManageGoodsApp.ViewModel;
using System.Windows;

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
    }
}
