using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace practica8
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeletePage : ContentPage
    {
        public DeletePage()
        {

            InitializeComponent();
        }
        private async void Button_elimina_Clicked(object sender, EventArgs e)
        {
            var datos = new _13090390
            {

                Nombre = Entry_Nombre.Text,
                Apellido = Entry_Apellido.Text,
                Direccion = Entry_Direccion.Text,
                Telefono = Entry_Telefono.Text,
                Carrera = Entry_Carrera.Text,
                Semestre = Entry_Semestre.Text,
                Correo = Entry_Correo.Text,
                Github = Entry_Github.Text
            };
            await DataPage.Tabla.UndeleteAsync(datos);
            await Navigation.PushModalAsync(new DataPage());

        }
    }
}