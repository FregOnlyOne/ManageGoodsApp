using System;
using ManageGoodsApp.ViewModel;
using System.Text.RegularExpressions;
using System.Windows;
using ManageGoodsApp.Model;

namespace ManageGoodsApp.View
{
    /// <summary>
    /// Логика взаимодействия для EditProductWindow.xaml
    /// </summary>
    public partial class EditProductWindow : Window
    {
        public EditProductWindow(Product productToEdit)
        {
            InitializeComponent();
            DataContext = new DataManage();
            DataManage.SelectedProduct = productToEdit;
            DataManage.ProductName = productToEdit.Name;
            DataManage.ProductBarcode = productToEdit.Barcode;
            DataManage.ProductWeight = Convert.ToString(Convert.ToDouble(productToEdit.Weight[..^3]) * 1000);
            DataManage.ProductCount = productToEdit.Count;
            DataManage.ProductPrice = productToEdit.Price;
            DataManage.ProductDiscount = productToEdit.Discount;
        }

        private void PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        
        private void PreviewPriceTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9^.]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
