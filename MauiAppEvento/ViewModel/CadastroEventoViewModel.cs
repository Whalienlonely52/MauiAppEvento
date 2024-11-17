using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace MauiAppEvento.ViewModels
{
    public class CadastroEventoViewModel : INotifyPropertyChanged
    {
        private string nome;
        private DateTime dataInicio = DateTime.Now;
        private DateTime dataTermino = DateTime.Now.AddDays(1);
        private int numeroParticipantes;
        private string local;
        private decimal custoPorParticipante;

        public string Nome
        {
            get => nome;
            set => SetProperty(ref nome, value);
        }

        public DateTime DataInicio
        {
            get => dataInicio;
            set => SetProperty(ref dataInicio, value);
        }

        public DateTime DataTermino
        {
            get => dataTermino;
            set => SetProperty(ref dataTermino, value);
        }

        public int NumeroParticipantes
        {
            get => numeroParticipantes;
            set => SetProperty(ref numeroParticipantes, value);
        }

        public string Local
        {
            get => local;
            set => SetProperty(ref local, value);
        }

        public decimal CustoPorParticipante
        {
            get => custoPorParticipante;
            set => SetProperty(ref custoPorParticipante, value);
        }

        public ICommand SalvarEventoCommand => new Command(SalvarEvento);

        private void SalvarEvento()
        {
            // Lógica para salvar o evento
            Console.WriteLine($"Evento '{Nome}' salvo com sucesso!");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string propertyName = "")
        {
            if (Equals(backingStore, value))
                return;

            backingStore = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
