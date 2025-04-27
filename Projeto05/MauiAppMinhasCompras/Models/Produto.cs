using System.ComponentModel;

namespace MauiAppMinhasCompras.Models
{
    public class Produto : INotifyPropertyChanged
    {
        private double _quantidade;
        private double _preco;

        public int Id { get; set; }  // Adicionando a propriedade Id

        public string Descricao { get; set; }

        public double Quantidade
        {
            get => _quantidade;
            set
            {
                if (_quantidade != value)
                {
                    _quantidade = value;
                    OnPropertyChanged(nameof(Quantidade));
                    OnPropertyChanged(nameof(TotalPreco));
                }
            }
        }

        public double Preco
        {
            get => _preco;
            set
            {
                if (_preco != value)
                {
                    _preco = value;
                    OnPropertyChanged(nameof(Preco));
                    OnPropertyChanged(nameof(TotalPreco));
                }
            }
        }

        public double TotalPreco => Quantidade * Preco;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Categoria { get; set; }
    }
}
