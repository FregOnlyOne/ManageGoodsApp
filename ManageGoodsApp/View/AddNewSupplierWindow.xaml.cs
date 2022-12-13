using ManageGoodsApp.ViewModel;
using System.Text.RegularExpressions;
using System.Windows;

namespace ManageGoodsApp.View
{
    /// <summary>
    /// Логика взаимодействия для AddNewSupplierWindow.xaml
    /// </summary>
    public partial class AddNewSupplierWindow : Window
    {
        public AddNewSupplierWindow()
        {
            InitializeComponent();
            DataContext = new DataManage();
        }

        private void PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
