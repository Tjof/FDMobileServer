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
    public partial class DrugstorePage : ContentPage
    {
        ApplicationViewModel viewModel;
        public DrugstorePage()
        {
            InitializeComponent();
            viewModel = new ApplicationViewModel();
            BindingContext = viewModel;
        }

        protected override async void OnAppearing()
        {
            await viewModel.GetDrugstores();
            base.OnAppearing();
        }
    }
}