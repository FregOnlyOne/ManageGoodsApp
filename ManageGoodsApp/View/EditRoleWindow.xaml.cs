using ManageGoodsApp.ViewModel;
using System.Windows;
using ManageGoodsApp.Model;

namespace ManageGoodsApp.View
{
    /// <summary>
    /// Логика взаимодействия для EditRoleWindow.xaml
    /// </summary>
    public partial class EditRoleWindow : Window
    {
        public EditRoleWindow(Role roleToEdit)
        {
            InitializeComponent();
            DataContext = new DataManage();
            DataManage.SelectedRole = roleToEdit;
            DataManage.RoleName = roleToEdit.Name;
        }
    }
}
