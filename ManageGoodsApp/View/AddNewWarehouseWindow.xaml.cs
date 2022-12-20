using ManageGoodsApp.ViewModel;
using System.Text.RegularExpressions;
using System.Windows;

namespace ManageGoodsApp.View
{
    /// <summary>
    /// Логика взаимодействия для AddNewWarehouseWindow.xaml
    /// </summary>
    public partial class AddNewWarehouseWindow : Window
    {
        public AddNewWarehouseWindow()
        {
            InitializeComponent();
            DataContext = new DataManage();
        }

        private void PreviewPhoneTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = Regex.IsMatch(e.Text, "[^0-9^(^)^+^-]+");
        }
    }
}
