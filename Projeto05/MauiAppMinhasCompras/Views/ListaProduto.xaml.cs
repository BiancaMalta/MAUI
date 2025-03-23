using MauiAppMinhasCompras.ViewModels;
using MauiAppMinhasCompras.Models;
using Microsoft.Maui.Controls;
using System.Threading.Tasks;

namespace MauiAppMinhasCompras.Views
{
    public partial class ListaProduto : ContentPage
    {
        private ListaProdutoViewModel _viewModel;

        public ListaProduto()
        {
            InitializeComponent();
            _viewModel = new ListaProdutoViewModel();
            BindingContext = _viewModel;
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NovoProduto(_viewModel));
        }

        private void SomarPrecos(object sender, EventArgs e)
        {
            DisplayAlert("Total", $"O total dos produtos é: R$ {_viewModel.TotalPreco:F2}", "OK");
        }
    }
}
