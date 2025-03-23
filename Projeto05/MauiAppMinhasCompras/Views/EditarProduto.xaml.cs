using MauiAppMinhasCompras.Models;
using Microsoft.Maui.Controls;

namespace MauiAppMinhasCompras.Views
{
    public partial class EditarProduto : ContentPage
    {
        private Produto _produto;

        public EditarProduto(Produto produto)
        {
            InitializeComponent();
            _produto = produto;
            BindingContext = _produto;
        }

        private async void ToolbarItem_Salvar_Clicked(object sender, EventArgs e)
        {
            try
            {
                await App.Db.Update(_produto);
                await DisplayAlert("Sucesso!", "Produto atualizado.", "OK");
                await Navigation.PopAsync(); // Volta para a tela anterior
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "OK");
            }
        }
    }
}
