using MauiAppEvento.Models;  
namespace MauiAppEvento.Views
{
    public partial class ResumoEvento : ContentPage
    {
     
        public ResumoEvento(Evento evento)
        {
            InitializeComponent();

           
            BindingContext = evento;
        }
    }
}



