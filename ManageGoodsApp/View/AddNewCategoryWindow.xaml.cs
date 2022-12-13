using System.Windows;
using ManageGoodsApp.ViewModel;

namespace ManageGoodsApp.View
{
    /// <summary>
    /// Логика взаимодействия для AddNewCategoryWindow.xaml
    /// </summary>
    public partial class AddNewCategoryWindow : Window
    {
        public AddNewCategoryWindow()
        {
            InitializeComponent();
            DataContext = new DataManage();
        }
    }
}
