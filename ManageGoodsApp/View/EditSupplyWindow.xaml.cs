using ManageGoodsApp.ViewModel;
using System.Text.RegularExpressions;
using System.Windows;
using ManageGoodsApp.Model;

namespace ManageGoodsApp.View
{
    /// <summary>
    /// Логика взаимодействия для EditSupplyWindow.xaml
    /// </summary>
    public partial class EditSupplyWindow : Window
    {
        public EditSupplyWindow(Supply supplyToEdit)
        {
            InitializeComponent();
            DataContext = new DataManage();
            DataManage.SelectedSupply = supplyToEdit;
            DataManage.SupplyCount = supplyToEdit.Count;
        }

        private void PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
