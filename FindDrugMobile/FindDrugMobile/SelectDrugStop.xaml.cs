using System;
using System.Collections.Generic;
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
        DrugsViewModel viewModel;
        public SelectDrugStop()
        {
            InitializeComponent();
            viewModel = new DrugsViewModel();
            BindingContext = viewModel;
        }

        async void FindRoutesClicked(object sender, EventArgs e)
        {
            int id_drug = (PickerDrug.SelectedItem as Drugs).id;
            int id_ost = (PickerStop.SelectedItem as Stops).id;
            await Navigation.PushAsync(new DrugstorePage(id_drug, id_ost));
        }
    }
}