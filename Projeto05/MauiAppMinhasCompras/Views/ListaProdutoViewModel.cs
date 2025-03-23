using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Threading.Tasks;
using MauiAppMinhasCompras.Models;

namespace MauiAppMinhasCompras.ViewModels
{
    public class ListaProdutoViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Produto> _produtos;
        private ObservableCollection<Produto> _produtosFiltrados;
        private string _termoBusca = string.Empty;

        public ObservableCollection<Produto> ProdutosFiltrados
        {
            get => _produtosFiltrados;
            set
            {
                _produtosFiltrados = value;
                OnPropertyChanged();
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

        public ListaProdutoViewModel()
        {
            _produtos = new ObservableCollection<Produto>();
            _produtosFiltrados = new ObservableCollection<Produto>();
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

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
