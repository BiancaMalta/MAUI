using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using MauiAppMinhasCompras.Models;
using MauiAppMinhasCompras.Views;
using Microsoft.Maui.Controls;

namespace MauiAppMinhasCompras.ViewModels
{
    public class ListaProdutoViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Produto> _produtos;
        private ObservableCollection<Produto> _produtosFiltrados;
        private string _termoBusca = string.Empty;
        private double _totalPreco;

        public ObservableCollection<Produto> ProdutosFiltrados
        {
            get => _produtosFiltrados;
            set
            {
                _produtosFiltrados = value;
                OnPropertyChanged();
                AtualizarTotal();
            }
        }

        public string TermoBusca
        {
            get => _termoBusca;
            set
            {
                if (_termoBusca != value)
                {
                    _termoBusca = value;
                    FiltrarProdutos();
                    OnPropertyChanged();
                }
            }
        }

        public double TotalPreco
        {
            get => _totalPreco;
            set
            {
                _totalPreco = value;
                OnPropertyChanged();
            }
        }

        public ICommand EditarProdutoCommand { get; }

        public ListaProdutoViewModel()
        {
            _produtos = new ObservableCollection<Produto>();
            _produtosFiltrados = new ObservableCollection<Produto>();
            EditarProdutoCommand = new Command<Produto>(EditarProduto);
            CarregarProdutos();
        }

        private async void CarregarProdutos()
        {
            var lista = await App.Db.GetAll();
            _produtos = new ObservableCollection<Produto>(lista);
            ProdutosFiltrados = new ObservableCollection<Produto>(_produtos);
        }

        private void FiltrarProdutos()
        {
            if (string.IsNullOrWhiteSpace(TermoBusca))
            {
                ProdutosFiltrados = new ObservableCollection<Produto>(_produtos);
            }
            else
            {
                var filtro = _produtos
                    .Where(p => p.Descricao.ToLower().Contains(TermoBusca.ToLower()))
                    .ToList();
                ProdutosFiltrados = new ObservableCollection<Produto>(filtro);
            }
        }

        private void AtualizarTotal()
        {
            TotalPreco = ProdutosFiltrados.Sum(p => p.Preco * p.Quantidade);
        }

        private async void EditarProduto(Produto produto)
        {
            if (produto != null)
            {
                await Application.Current.MainPage.Navigation.PushAsync(new EditarProduto(produto));
            }
        }

        public async Task AdicionarProduto(Produto produto)
        {
            await App.Db.Insert(produto);
            CarregarProdutos();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
