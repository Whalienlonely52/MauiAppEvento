using MauiAppEvento.Models;  

namespace MauiAppEvento.Views
{
    public partial class CadastroEvento : ContentPage
    {
        public CadastroEvento()
        {
            InitializeComponent();
        }

        private async void OnCadastrarClicked(object sender, EventArgs e)
        {
            try
            {
               
                if (!int.TryParse(NumeroParticipantesEntry.Text, out int numeroParticipantes))
                {
                    await DisplayAlert("Erro", "Número de participantes inválido.", "OK");
                    return;
                }

                if (!decimal.TryParse(CustoPorParticipanteEntry.Text, out decimal custoPorParticipante))
                {
                    await DisplayAlert("Erro", "Custo por participante inválido.", "OK");
                    return;
                }

                
                if (string.IsNullOrWhiteSpace(NomeEntry.Text))
                {
                    await DisplayAlert("Erro", "O nome do evento é obrigatório.", "OK");
                    return;
                }

                if (string.IsNullOrWhiteSpace(LocalEntry.Text))
                {
                    await DisplayAlert("Erro", "O local do evento é obrigatório.", "OK");
                    return;
                }

               
                if (DataTerminoPicker.Date < DataInicioPicker.Date)
                {
                    await DisplayAlert("Erro", "A data de término não pode ser antes da data de início.", "OK");
                    return;
                }
                var evento = new Evento
                {
                    Nome = NomeEntry.Text,
                    DataInicio = DataInicioPicker.Date,
                    DataTermino = DataTerminoPicker.Date,
                    NumeroParticipantes = numeroParticipantes,
                    Local = LocalEntry.Text,
                    CustoPorParticipante = custoPorParticipante
                };
               
                if (string.IsNullOrWhiteSpace(evento.Nome) || string.IsNullOrWhiteSpace(evento.Local))
                {
                    await DisplayAlert("Erro", "Preencha todos os campos!", "OK");
                    return;
                }

                if (evento.DataTermino < evento.DataInicio)
                {
                    await DisplayAlert("Erro", "A data de término não pode ser antes da data de início.", "OK");
                    return;
                }

              
                await Navigation.PushAsync(new ResumoEvento(evento));
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", "Verifique os dados informados! " + ex.Message, "OK");
            }
        }
    }
}
