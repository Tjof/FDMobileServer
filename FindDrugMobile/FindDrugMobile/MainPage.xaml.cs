using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FindDrugMobile
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button1_Clicked(object sender, EventArgs e)
        {
            Button1.Text = "Нажато!!!";
            Button1.BackgroundColor = Color.Red;

        }
    }
}
