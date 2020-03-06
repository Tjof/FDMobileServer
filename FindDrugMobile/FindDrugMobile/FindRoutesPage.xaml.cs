using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FindDrugMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FindRoutesPage : ContentPage
    {
        ApplicationViewModel viewModel;
        public FindRoutesPage(Drug drug, Stop ost)
        {
            InitializeComponent();
            viewModel = new ApplicationViewModel(drug, ost);
            BindingContext = viewModel;
            DrugName.Text = drug.название;
            StopName.Text = "Ваша остановка: " + ost.название;
        }

        protected override async void OnAppearing()
        {
            await viewModel.GetDrugstores();
            base.OnAppearing();
        }
    }
}