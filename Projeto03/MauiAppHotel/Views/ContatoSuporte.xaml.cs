using Microsoft.Maui.Controls;
using System;

namespace MauiAppHotel.Views
{
    public partial class ContatoSuporte : ContentPage
    {
        public ContatoSuporte()
        {
            InitializeComponent();
        }

        // Método para abrir o aplicativo de e-mail
        private async void OnEmailButtonClicked(object sender, EventArgs e)
        {
            try
            {
                // Configuração do e-mail
                var email = new Uri("mailto:suporte@hotel.com");
                await Launcher.Default.OpenAsync(email);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", "Não foi possível abrir o aplicativo de e-mail.", "OK");
            }
        }
    }
}