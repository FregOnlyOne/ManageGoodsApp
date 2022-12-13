﻿using ManageGoodsApp.ViewModel;
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
            DataManage.SupplierAddress = supplierToEdit.Address;
            DataManage.SupplierPhone = supplierToEdit.Phone;
        }

        private void PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}