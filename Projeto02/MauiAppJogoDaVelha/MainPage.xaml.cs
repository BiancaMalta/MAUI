using System;

namespace MauiAppJogoDaVelha
{
    public partial class MainPage : ContentPage
    {
        int[][] vit = new int[8][] {
            new int[3] { 0, 1, 2 },
            new int[3] { 3, 4, 5 },
            new int[3] { 6, 7, 8 },
            new int[3] { 0, 3, 6 },
            new int[3] { 1, 4, 7 },
            new int[3] { 2, 5, 8 },
            new int[3] { 0, 4, 8 },
            new int[3] { 2, 4, 6 } 
        };
        string vez = "X";

        public MainPage()
        {
            InitializeComponent();
        }   
        private void Button_Clicked(object sender, EventArgs e)
        {
            int contador = 0;
            Button btn = (Button)sender;
            contador++;
            btn.IsEnabled = false;

            if(vez == "X")
            {
                btn.Text = "X";
                vez = "O";
            } else
            {
                btn.Text = "O";
                vez = "X";
            }



            /* Verificando se ganhou */
            Button[] botoes = { btn10, btn11, btn12, btn20, btn21, btn22, btn30, btn31, btn32 };
            foreach (int[] v in vit)
            {
                if (botoes[v[0]].Text == botoes[v[1]].Text && botoes[v[1]].Text == botoes[v[2]].Text && !string.IsNullOrEmpty(botoes[v[0]].Text))
                {
                    DisplayAlert("Fim de Jogo", "O jogador " + botoes[v[0]].Text + " ganhou!", "OK");
                    Zerar();
                    return;
                }
            }
            if(contador == 9)
            {
                DisplayAlert("Fim de Jogo", "Deu velha!", "OK");
                Zerar();
            }


        } // Fecha método

        void Zerar()
        {
            Button[] botoes = { btn10, btn11, btn12, btn20, btn21, btn22, btn30, btn31, btn32 };
            for (int i = 0; i < 9; i++)
            {
                botoes[i].Text = "";
                botoes[i].IsEnabled = true;
            }
            vez = "X";
        }

    } // Fecha Classe
} // Fecha Namespace
