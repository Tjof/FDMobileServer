using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FindDrugMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectDrugStop : ContentPage
    {
        DrugsStopsViewModel viewModel;
        private int id_drug;
        private int id_stop;
        public SelectDrugStop()
        {
            InitializeComponent();
            viewModel = new DrugsStopsViewModel();
            BindingContext = viewModel;

            searchDrug.TextChanged += (s, e) =>
            {

                searchResultsDrug.ItemsSource = viewModel.Drugss;

                if (string.IsNullOrEmpty(searchDrug.Text))
                {
                    searchResultsDrug.ItemsSource = null;
                    searchResultsDrug.IsVisible = false;
                }
                else
                {
                    searchResultsDrug.ItemsSource = viewModel.Drugss.Where(x => x.название.StartsWith(searchDrug.Text, StringComparison.CurrentCultureIgnoreCase));
                    if (searchResultsDrug.ItemsSource == null)
                        searchResultsDrug.IsVisible = false;
                    else
                        searchResultsDrug.IsVisible = true;

                }

            };
            searchStop.TextChanged += (s, e) =>
            {

                searchResultsStop.ItemsSource = viewModel.Stopss;

                if (string.IsNullOrEmpty(searchStop.Text))
                {
                    searchResultsStop.ItemsSource = null;
                    searchResultsStop.IsVisible = false;
                }
                else
                {
                    searchResultsStop.ItemsSource = viewModel.Stopss.Where(x => x.название.StartsWith(searchStop.Text, StringComparison.CurrentCultureIgnoreCase));
                    if (searchResultsStop.ItemsSource == null)
                        searchResultsStop.IsVisible = false;
                    else
                        searchResultsStop.IsVisible = true;
                }

            };
            searchResultsDrug.ItemSelected += (s, e) =>
            {
                searchDrug.Text = (searchResultsDrug.SelectedItem as Drug).название;
                id_drug = (searchResultsDrug.SelectedItem as Drug).id;
                searchResultsDrug.IsVisible = false;
            };
            searchResultsStop.ItemSelected += (s, e) =>
            {
                searchStop.Text = (searchResultsStop.SelectedItem as Stop).название;
                id_stop = (searchResultsStop.SelectedItem as Stop).id;
                searchResultsStop.IsVisible = false;
            };
            searchDrug.Unfocused += (s, e) =>
            {
                searchResultsDrug.IsVisible = false;
            };
            searchStop.Unfocused += (s, e) =>
            {
                searchResultsStop.IsVisible = false;
            };
        }

        async void FindRoutesClicked(object sender, EventArgs e)
        {
            var drug = new Drug
            {
                id = id_drug,
                название = searchDrug.Text
            };
            var ost = new Stop
            {
                id = id_stop,
                название = searchStop.Text
            };
            if (drug.id != 0 || ost.id != 0)
            {
                await Navigation.PushAsync(new FindRoutesPage(drug, ost));
            }
            else
            {
                await DisplayAlert("Ошибка", "Выбери данные правильно", "OK");
            }
        }
    }
}