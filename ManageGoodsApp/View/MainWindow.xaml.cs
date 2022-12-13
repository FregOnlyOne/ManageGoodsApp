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
        }
    }
}
