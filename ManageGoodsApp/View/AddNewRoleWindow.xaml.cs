using ManageGoodsApp.ViewModel;
using System.Windows;

namespace ManageGoodsApp.View
{
    /// <summary>
    /// Логика взаимодействия для AddNewRoleWindow.xaml
    /// </summary>
    public partial class AddNewRoleWindow : Window
    {
        public AddNewRoleWindow()
        {
            InitializeComponent();
            DataContext = new DataManage();
        }
    }
}
