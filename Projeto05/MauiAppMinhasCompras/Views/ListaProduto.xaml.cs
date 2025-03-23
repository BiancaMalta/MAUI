using MauiAppMinhasCompras.ViewModels;
using Microsoft.Maui.Controls;

namespace MauiAppMinhasCompras.Views
{
    public partial class ListaProduto : ContentPage
    {
        public ListaProduto()
        {
            InitializeComponent();
            BindingContext = new ListaProdutoViewModel();
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            try
            {
                Navigation.PushAsync(new Views.NovoProduto());
            }
            catch (Exception ex)
            {
                DisplayAlert("Ops", ex.Message, "OK");
            }
        }
    }
}
