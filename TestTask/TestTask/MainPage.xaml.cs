using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TestTask
{
    public partial class MainPage : ContentPage
    {
        private string from="en";
        private string to="ru";
        private TranslateAPI api;

        public MainPage()
        {
            InitializeComponent();
            pickerFrom.SelectedIndex = 0;
            pickerTo.SelectedIndex = 4;
            api = new TranslateAPI();
        }
        private async void OnBtnTrnsltClicked(object sender, EventArgs e)
        {
            string source = fromEn.Text;
            string lang = from+'-'+to;
            string result = api.Translate(source, lang);
            toEd.Text = result;
            if (!result.Equals(source))
            {
                await App.DataBase.InsertItem(new Item { fromLang=from,toLang=to,fromText=source,toText=result});
            }
        }

        private async void OnTbiClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListHitoryPage());
        }
        private void OnPickerFromSelectIndexChanged(object sender, EventArgs e)
        {
            switch (pickerFrom.SelectedIndex)
            {
                case 0:
                    from = "en";
                    break;
                case 1:
                    from = "fr";
                    break;
                case 2:
                    from = "de";
                    break;
                case 3:
                    from = "it";
                    break;
                case 4:
                    from = "ru";
                    break;
            }
        }
        private void OnPickerToSelectIndexChanged(object sender, EventArgs e)
        {
            switch (pickerTo.SelectedIndex)
            {
                case 0:
                    to = "en";
                    break;
                case 1:
                    to = "fr";
                    break;
                case 2:
                    to = "de";
                    break;
                case 3:
                    to = "it";
                    break;
                case 4:
                    to = "ru";
                    break;
            }
        }
        private void OnBtnSwapClicked(object sender, EventArgs e)
        {
            int idFrom = pickerFrom.SelectedIndex;
            pickerFrom.SelectedIndex = pickerTo.SelectedIndex;
            pickerTo.SelectedIndex = idFrom;
        }
    }
}
