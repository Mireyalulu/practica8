using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Microsoft.WindowsAzure.MobileServices;
using SQLite;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace practica8
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DataPage : ContentPage
    {
        public ObservableCollection<_13090390> Items { get; set; }
        //SQLiteConnection database;
        public static MobileServiceClient cliente;
        public static IMobileServiceTable<_13090390> Tabla;
        //MobileServiceUser usuario;


        public DataPage()
        {
            InitializeComponent();
            //string db;
            //db = DependencyService.Get<SQLite>().GetLocalFilePath("TESHDB.db");
            //database = new SQLiteConnection(db);
            //database.CreateTable<TESHDatos>();
            cliente = new MobileServiceClient(AzureConnection.AzureURL);
            //Items = new ObservableCollection<TESHDatos> { database.Table<TESHDatos>() };
            //BindingContext = this;
            Tabla = cliente.GetTable<_13090390>();
            LeerTabla();
            // Tabla.IncludeDeleted();
            //Tabla.UndeleteAsync(Id);

        }

        async void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
            await Navigation.PushModalAsync(new SelectPage(e.SelectedItem as _13090390));
        }
        private async void LeerTabla()
        {
            IEnumerable<_13090390> elementos = await Tabla.ToEnumerableAsync();
            Items = new ObservableCollection<_13090390>(elementos);
            BindingContext = this;
        }

        private void Button_Insertar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new InsertPage());
        }

        private void Button_elimina_Clicked(object sender, EventArgs e)
        {
            LeerEliminados();

        }

        private async void LeerEliminados()
        {
            IEnumerable<_13090390> elementos = await Tabla.IncludeDeleted().ToEnumerableAsync();
            Items = new ObservableCollection<_13090390>(elementos);
            BindingContext = this;
            InitializeComponent();
        }
    }
}