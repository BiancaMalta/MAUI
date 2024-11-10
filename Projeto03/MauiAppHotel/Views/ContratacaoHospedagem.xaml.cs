using MauiAppHotel.Models;

namespace MauiAppHotel.Views;

public partial class ContratacaoHospedagem : ContentPage
{
    App PropriedadesApp;

    public ContratacaoHospedagem()
    {
        InitializeComponent();

        PropriedadesApp = Application.Current as App ?? throw new InvalidOperationException("Application.Current is not of type App");

        pck_quarto.ItemsSource = PropriedadesApp.lista_quartos ?? throw new InvalidOperationException("lista_quartos is null");

        dtpck_checkin.MinimumDate = DateTime.Now;
        dtpck_checkin.MaximumDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, DateTime.Now.Day);

        dtpck_checkout.MinimumDate = dtpck_checkin.Date.AddDays(1);
        dtpck_checkout.MaximumDate = dtpck_checkin.Date.AddMonths(6);
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            Hospedagem h = new Hospedagem
            {
                QuartoSelecionado = (Quarto)pck_quarto.SelectedItem,
                QntAdultos = Convert.ToInt32(stp_adultos.Value),
                QntCriancas = Convert.ToInt32(stp_criancas.Value),
                DataCheckIn = dtpck_checkin.Date,
                DataCheckOut = dtpck_checkout.Date,
            };

            await Navigation.PushAsync(new HospedagemContratada()
            {
                BindingContext = h
            });

        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }

    private async void OnMenuClicked(object sender, EventArgs e)
    {
        var action = await DisplayActionSheet("Menu", "Cancelar", null, "Sobre", "Contato e Suporte");

        switch (action)
        {
            case "Sobre":
                await Navigation.PushAsync(new SobrePage());
                break;
            case "Contato e Suporte":
                await Navigation.PushAsync(new ContatoSuporte());
                break;
        }
    }

    private async void ButtonSobre_Clicked(object sender, EventArgs e)
    {
        try
        {
            if (Navigation != null)
            {
                await Navigation.PushAsync(new SobrePage());
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Navigation is null");
                await DisplayAlert("Error", "Navigation is not available.", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }

    private void dtpck_checkin_DateSelected(object sender, DateChangedEventArgs e)
    {
        if (sender is DatePicker elemento)
        {
            DateTime data_selecionada_checkin = elemento.Date;

            dtpck_checkout.MinimumDate = data_selecionada_checkin.AddDays(1);
            dtpck_checkout.MaximumDate = data_selecionada_checkin.AddMonths(6);
        }
    }
}
