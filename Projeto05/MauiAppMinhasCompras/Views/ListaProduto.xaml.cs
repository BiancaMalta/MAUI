using MauiAppMinhasCompras.ViewModels;
using Microsoft.Maui.Controls;
using MauiAppMinhasCompras.Models;
using System.Collections.ObjectModel;

namespace MauiAppMinhasCompras.Views
{
    public partial class ListaProduto : ContentPage
    {
        ObservableCollection<Produto> lista = new ObservableCollection<Produto>();

        public ListaProduto()
        {
            InitializeComponent();
            lst_produtos.ItemsSource = lista;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing(); // Essa linha é importante pra chamar a implementação da classe base

            lista.Clear();

            if (BindingContext is not ListaProdutoViewModel)
            {
                BindingContext = new ListaProdutoViewModel();
            }

            List<Produto> tmp = await App.Db.GetAll();
            tmp.ForEach(i => lista.Add(i));

            var categorias = tmp.Select(p => p.Categoria).Distinct().ToList();
            picker_categoria.ItemsSource = categorias;
        }


        private async void btnLimparFiltro_Clicked(object sender, EventArgs e)
        {
            try
            {
                // Limpa a seleção do picker
                picker_categoria.SelectedIndex = -1;

                // Recarrega todos os produtos na lista
                lista.Clear();
                List<Produto> tmp = await App.Db.GetAll();
                tmp.ForEach(i => lista.Add(i));
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "OK");
            }
        }

        private async void picker_categoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string categoriaSelecionada = picker_categoria.SelectedItem as string;
                if (categoriaSelecionada != null)
                {
                    lista.Clear();
                    List<Produto> tmp = await App.Db.SearchByCategory(categoriaSelecionada);
                    tmp.ForEach(i => lista.Add(i));
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "OK");
            }
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            try
            {
                Navigation.PushAsync(new Views.NovoProduto());
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "OK");
            }
        }

        private async void txt_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                string q = e.NewTextValue;
                lst_produtos.IsRefreshing = true;

                lista.Clear();
                List<Produto> tmp = await App.Db.Search(q);
                tmp.ForEach(i => lista.Add(i));
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "OK");
            }
            finally
            {
                lst_produtos.IsRefreshing = false;
            }
        }

        private void ToolbarItem_Clicked_1(object sender, EventArgs e)
        {
            double soma = lista.Sum(i => i.Total);
            string msg = $"O total é {soma:C}";
            DisplayAlert("Total dos Produtos", msg, "OK");
        }

        private async void MenuItem_Clicked(object sender, EventArgs e)
        {
            try
            {
                MenuItem selecinado = sender as MenuItem;
                Produto p = selecinado.BindingContext as Produto;

                bool confirm = await DisplayAlert("Tem Certeza?", $"Remover {p.Descricao}?", "Sim", "Não");

                if (confirm)
                {
                    await App.Db.Delete(p.Id);
                    lista.Remove(p);
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "OK");
            }
        }

        private async void btnRelatorio_Clicked(object sender, EventArgs e)
        {
            try
            {
                var relatorio = await App.Db.GetTotalByCategory();
                string msg = string.Join("\n", relatorio.Select(r => $"{r.Key}: {r.Value:C}"));
                await DisplayAlert("Relatório de Gastos", msg, "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "OK");
            }
        }

        private async void lst_produtos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                Produto p = e.SelectedItem as Produto;
                if (p != null)
                {
                    await Navigation.PushAsync(new Views.EditarProduto(p));
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "OK");
            }
        }

        private async void lst_produtos_Refreshing(object sender, EventArgs e)
        {
            try
            {
                lista.Clear();
                List<Produto> tmp = await App.Db.GetAll();
                tmp.ForEach(i => lista.Add(i));
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "OK");
            }
            finally
            {
                lst_produtos.IsRefreshing = false;
            }
        }
    }
}
