using ManageGoodsApp.ViewModel;
using System.Text.RegularExpressions;
using System.Windows;
using ManageGoodsApp.Model;

namespace ManageGoodsApp.View
{
    /// <summary>
    /// Логика взаимодействия для EditWarehouseWindow.xaml
    /// </summary>
    public partial class EditWarehouseWindow : Window
    {
        public EditWarehouseWindow(Warehouse warehouseToEdit)
        {
            InitializeComponent();
            DataContext = new DataManage();
            DataManage.SelectedWarehouse = warehouseToEdit;
            DataManage.WarehouseName = warehouseToEdit.Name;
            DataManage.WarehouseAddress = warehouseToEdit.Address;
            DataManage.WarehousePhone = warehouseToEdit.Phone;
        }

        private void PreviewPhoneTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = Regex.IsMatch(e.Text, "[^0-9^(^)^+^-]+");
        }
    }
}
