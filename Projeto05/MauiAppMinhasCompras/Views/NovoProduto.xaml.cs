using MauiAppMinhasCompras.Models;
using MauiAppMinhasCompras.ViewModels;
using Microsoft.Maui.Controls;

namespace MauiAppMinhasCompras.Views
{
    public partial class NovoProduto : ContentPage
    {
        private ListaProdutoViewModel _viewModel;

        public NovoProduto(ListaProdutoViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            try
            {
                Produto p = new Produto
                {
                    Descricao = txt_descricao.Text,
                    Quantidade = Convert.ToDouble(txt_quantidade.Text),
                    Preco = Convert.ToDouble(txt_preco.Text)
                };

                await _viewModel.AdicionarProduto(p);
                await DisplayAlert("Sucesso!", "Registro Inserido", "OK");
                await Navigation.PopAsync(); // Fecha a tela ao salvar
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "OK");
            }
        }
    }
}
