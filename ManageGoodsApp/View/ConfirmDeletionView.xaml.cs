using System.Windows;

namespace ManageGoodsApp.View;

public partial class ConfirmDeletionView : Window
{
    public ConfirmDeletionView(string text)
    {
        InitializeComponent();
        MessageText.Text = text;
    }
    
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }
}