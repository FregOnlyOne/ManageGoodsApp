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

        private void PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
