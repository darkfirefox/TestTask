using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestTask
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListHitoryPage : ContentPage
    {

        public ListHitoryPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            ListViewHistory.ItemsSource = await App.DataBase.GetItems();
        }

        private async void OnBtnDeleteClicked(object sender, EventArgs e)
        {
            await App.DataBase.DeleteItem((Item)((MenuItem)sender).CommandParameter);
            ListViewHistory.ItemsSource = await App.DataBase.GetItems();
        }
        private async void OnTbiClicked(object sender, EventArgs e)
        {
            await App.DataBase.DeleteItems();
            ListViewHistory.ItemsSource = await App.DataBase.GetItems();
        }
    }
}
