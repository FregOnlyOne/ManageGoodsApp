using System.Windows;
using ManageGoodsApp.Model;
using ManageGoodsApp.ViewModel;

namespace ManageGoodsApp.View
{
    /// <summary>
    /// Логика взаимодействия для EditCategoryWindow.xaml
    /// </summary>
    public partial class EditCategoryWindow : Window
    {
        public EditCategoryWindow(Category categoryToEdit)
        {
            InitializeComponent();
            DataContext = new DataManage();
            DataManage.SelectedCategory = categoryToEdit;
            DataManage.CategoryName = categoryToEdit.Name;
        }
    }
}
