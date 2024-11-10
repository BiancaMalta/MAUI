namespace MauiAppMeuCombustivel
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {               
                // Coletando os valores dos campos de entrada
                string marca = txt_marca.Text;
                string modelo = txt_modelo.Text;
                double etanol = Convert.ToDouble(txt_etanol.Text);
                double gasolina = Convert.ToDouble(txt_gasolina.Text);

                string msg = "";

                // Lógica de cálculo para comparar os combustíveis
                if (etanol <= (gasolina * 0.7))
                {
                    msg = $"O etanol está compensando para o seu {marca} {modelo}.";
                }
                else
                {
                    msg = $"A gasolina está compensando para o seu {marca} {modelo}.";
                }

                // Exibe a mensagem do resultado
                DisplayAlert("Calculado", msg, "OK");

            }
            catch (Exception ex)
            {
                DisplayAlert("Ops", ex.Message, "Fechar");
            }
        }
    }
}