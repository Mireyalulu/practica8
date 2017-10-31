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
    public partial class SelectPage : ContentPage
    {
        public SelectPage(object selectedItem)
        {
            var dato = selectedItem as _13090390;
            BindingContext = dato;

            InitializeComponent();
        }
       

        private async void Button_Actualizar_Clicked_1(object sender, EventArgs e)
        {
            var datos = new _13090390
            {
                Id = Entry_Id.Text,
                Nombre = Entry_Nombre.Text,
                Apellido = Entry_Apellido.Text,
                Direccion = Entry_Direccion.Text,
                Telefono = Entry_Telefono.Text,
                Carrera = Entry_Carrera.Text,
                Semestre = Entry_Semestre.Text,
                Correo = Entry_Correo.Text,
                Github = Entry_Github.Text
            };
            await DataPage.Tabla.UpdateAsync(datos);
            await Navigation.PushModalAsync(new DataPage());
        }

        

        private async void Button_Eliminar_Clicked_1(object sender, EventArgs e)
        {
            var datos = new _13090390
            { 
                Id = Entry_Id.Text,
                Nombre = Entry_Nombre.Text,
                Apellido = Entry_Apellido.Text,
                Direccion = Entry_Direccion.Text,
                Telefono = Entry_Telefono.Text,
                Carrera = Entry_Carrera.Text,
                Semestre = Entry_Semestre.Text,
                Correo = Entry_Correo.Text,
                Github = Entry_Github.Text
            };
            await DataPage.Tabla.DeleteAsync(datos);
            await Navigation.PushModalAsync(new DataPage());
        }

        private async void Button_Recuperar_Clicked(object sender, EventArgs e)
        {
            
                var datos = new _13090390
                {
                    Id = Entry_Id.Text,
                };
                await DataPage.Tabla.UndeleteAsync(datos);
                await Navigation.PushModalAsync(new DataPage());
            
        }
            
    }
}


