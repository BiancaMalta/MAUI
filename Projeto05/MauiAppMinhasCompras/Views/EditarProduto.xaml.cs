using MauiAppMinhasCompras.Models;
 
 namespace MauiAppMinhasCompras.Views;

public partial class EditarProduto : ContentPage
{
    private Produto _produto;
    public EditarProduto(Produto produto)
    {
        InitializeComponent();
        _produto = produto;
        BindingContext = _produto;
    }

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            Produto produto_anexado = BindingContext as Produto;

            Produto p = new Produto
            {
                Id = produto_anexado.Id,
                Categoria = txt_categoria.Text,
                Descricao = txt_descricao.Text,
                Quantidade = Convert.ToDouble(txt_quantidade.Text),
                Preco = Convert.ToDouble(txt_preco.Text)
            };

            await App.Db.Update(p);
            await DisplayAlert("Sucesso!", "Registro Atualizado", "OK");
            await Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }
}
