using MauiAppMinhasCompras.ViewModels;
using Microsoft.Maui.Controls;

namespace MauiAppMinhasCompras.Views
{
    public partial class ListaProduto : ContentPage
    {
        public ListaProduto()
        {
            InitializeComponent();

            // Certifique-se de que não está sobrescrevendo o BindingContext se já definido no XAML
            if (BindingContext is not ListaProdutoViewModel)
            {
                BindingContext = new ListaProdutoViewModel();
            }
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (BindingContext is ListaProdutoViewModel viewModel)
                {
                    Navigation.PushAsync(new NovoProduto(viewModel));
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        private void SomarPrecos(object sender, EventArgs e)
        {
            if (BindingContext is ListaProdutoViewModel viewModel)
            {
                DisplayAlert("Total", $"O total dos produtos é: R$ {viewModel.TotalPreco:F2}", "OK");
            }
        }
    }
}
