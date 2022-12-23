using ManageGoodsApp.ViewModel;
using System.Text.RegularExpressions;
using System.Windows;
using ManageGoodsApp.Model;

namespace ManageGoodsApp.View
{
    /// <summary>
    /// Логика взаимодействия для EditSupplierWindow.xaml
    /// </summary>
    public partial class EditSupplierWindow : Window
    {
        public EditSupplierWindow(Supplier supplierToEdit)
        {
            InitializeComponent();
            DataContext = new DataManage();
            DataManage.SelectedSupplier = supplierToEdit;
            DataManage.SupplierName = supplierToEdit.Name;
            DataManage.SupplierPhysicalAddress = supplierToEdit.PhysicalAddress;
            DataManage.SupplierLegalAddress = supplierToEdit.LegalAddress;
            DataManage.SupplierTaxIdentificationNumber = supplierToEdit.TaxIdentificationNumber;
            DataManage.SupplierEmail = supplierToEdit.Email;
            DataManage.SupplierPhone = supplierToEdit.Phone;
        }

        private void PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        
        private void PreviewPhoneTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = Regex.IsMatch(e.Text, "[^0-9^(^)^+^-]+");
        }
    }
}
