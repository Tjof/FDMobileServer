using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System;
using System.Threading;

namespace FindDrugMobile
{
    class DrugsStopsViewModel : INotifyPropertyChanged
    {
        //bool initialized = false;   // была ли начальная инициализация
        //private bool isBusy;    // идет ли загрузка с сервера

        public Drug[] Drugss { get => drugss; set { drugss = value; OnPropertyChanged(); } }
        public Stop[] Stopss { get => stopss; set { stopss = value; OnPropertyChanged(); } }
        DrugService drugsService = new DrugService();
        StopService stopsService = new StopService();
        private Drug[] drugss;
        private Stop[] stopss;

        public event PropertyChangedEventHandler PropertyChanged;

        //public bool IsBusy
        //{
        //    get { return isBusy; }
        //    set
        //    {
        //        isBusy = value;
        //        OnPropertyChanged("IsBusy");
        //        OnPropertyChanged("IsLoaded");
        //    }
        //}
        //public bool IsLoaded
        //{
        //    get { return !isBusy; }
        //}

        public DrugsStopsViewModel()
        {
            //IsBusy = true;
            //Task.Run(async () => {
            //    var d = await GetDrugs();
            //    Thread.Sleep(r.Next(0, 10000));
            //    Drugss = d;

            //    lock (syncObject)
            //    {
            //        if (Drugss != null && Stopss != null)
            //        {
            //            IsBusy = false;
            //        }
            //    }
            //});
            //Task.Run(async () => {
            //    var s = await GetStops();
            //    Thread.Sleep(r.Next(0, 10000));
            //    Stopss = s;

            //    lock (syncObject)
            //    {
            //        if (Drugss != null && Stopss != null)
            //        {
            //            IsBusy = false;
            //        }
            //    }
            //});
            Task.Run(async () => Drugss = await GetDrugs());
            Task.Run(async () => Stopss = await GetStops());
        }
        protected void OnPropertyChanged([CallerMemberName]string propName="")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        //Random r = new Random();
        //Object syncObject = new object();

        public async Task<Drug[]> GetDrugs()
        {
            var drugs = await drugsService.Get();
            
            return drugs;

        }

        public async Task<Stop[]> GetStops()
        {
            var stops = await stopsService.Get();

            return stops;
        }
    }
}
