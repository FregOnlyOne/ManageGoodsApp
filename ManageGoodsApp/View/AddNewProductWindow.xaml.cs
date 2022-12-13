using System.Text.RegularExpressions;
using System.Windows;
using ManageGoodsApp.ViewModel;

namespace ManageGoodsApp.View
{
    /// <summary>
    /// Логика взаимодействия для AddNewProductWindow.xaml
    /// </summary>
    public partial class AddNewProductWindow : Window
    {
        public AddNewProductWindow()
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
