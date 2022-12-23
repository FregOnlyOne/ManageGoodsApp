using System.Windows;
using System.Windows.Controls;
using ManageGoodsApp.ViewModel;

namespace ManageGoodsApp.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ListView AllProductsView;
        public static ListView AllCategoriesView;
        public static ListView AllSuppliersView;
        public static ListView AllSuppliesView;
        public static ListView AllWarehousesView;
        public static ListView AllUsersView;
        public static ListView AllRolesView;
        public static ListView AllLogsView;
        
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new DataManage();
            AllProductsView = ViewAllProducts;
            AllCategoriesView = ViewAllCategories;
            AllSuppliersView = ViewAllSuppliers;
            AllSuppliesView = ViewAllSupplies;
            AllWarehousesView = ViewAllWarehouses;
            AllUsersView = ViewAllUsers;
            AllRolesView = ViewAllRoles;
            AllLogsView = ViewAllLogs;

            if (DataManage.AuthUserRoleName == "Кладовщик")
            {
                CategoriesTabItem.Visibility = Visibility.Collapsed;
                WarehousesTabItem.Visibility = Visibility.Collapsed;
                SuppliersTabItem.Visibility = Visibility.Collapsed;
                SuppliesContextMenu.Visibility = Visibility.Collapsed;
                UsersTabItem.Visibility = Visibility.Collapsed;
                RolesTabItem.Visibility = Visibility.Collapsed;
                NewProductBtnSeparator.Visibility = Visibility.Collapsed;
                NewSupplyBtn.Visibility = Visibility.Collapsed;
                NewSupplyBtnSeparator.Visibility = Visibility.Collapsed;
                NewUserBtn.Visibility = Visibility.Collapsed;
            }
            else if (DataManage.AuthUserRoleName == "Менеджер")
            {
                UsersTabItem.Visibility = Visibility.Collapsed;
                RolesTabItem.Visibility = Visibility.Collapsed;
                NewUserBtn.Visibility = Visibility.Collapsed;
                NewSupplyBtnSeparator.Visibility = Visibility.Collapsed;
            }
        }
    }
}
