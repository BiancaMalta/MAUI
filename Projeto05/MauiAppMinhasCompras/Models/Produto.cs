using System.ComponentModel;

namespace MauiAppMinhasCompras.Models
{
    public class Produto : INotifyPropertyChanged
    {
        private double _quantidade;
        private double _preco;

        public string Descricao { get; set; }

        public double Quantidade
        {
            get => _quantidade;
            set
            {
                _quantidade = value;
                OnPropertyChanged(nameof(Quantidade));
                OnPropertyChanged(nameof(TotalPreco));
            }
        }

        public double Preco
        {
            get => _preco;
            set
            {
                _preco = value;
                OnPropertyChanged(nameof(Preco));
                OnPropertyChanged(nameof(TotalPreco));
            }
        }

        public double TotalPreco => Quantidade * Preco;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string nome)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nome));
        }
    }
}
