using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Runtime.CompilerServices;

namespace FindDrugMobile
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        bool initialized = false;   // была ли начальная инициализация
        private bool isBusy;    // идет ли загрузка с сервера
        private int id_drug;
        private int id_stop;

        //public IEnumerable<Drugstore> Drugstores { get; set; }
        FindRoutesService drugstoreService = new FindRoutesService();
        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                OnPropertyChanged("IsBusy");
                OnPropertyChanged("IsLoaded");
            }
        }
        public bool IsLoaded
        {
            get { return !isBusy; }
        }

        public ApplicationViewModel(Drug drug, Stop ost)
        {
            //Drugstores = new ObservableCollection<Drugstore>();
            IsBusy = false;
            id_drug = drug.id;
            id_stop = ost.id;
        }
        protected void OnPropertyChanged([CallerMemberName]string propName="")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        public object[] OrderedDrugs { get => orderedDrugs; set { orderedDrugs = value; OnPropertyChanged(); } }
        private object[] orderedDrugs;
        public async Task GetDrugstores()
        {
            if (initialized == true) return;
            IsBusy = true;
            IEnumerable<Drugstore> drugstores = await drugstoreService.Get(id_drug, id_stop);

            //очищаем список
            //Drugstores = drugstores;
            var result = drugstores
                .GroupBy(r => new 
                { 
                    r.название, 
                    r.Адрес,
                    r.время_работы, 
                    r.название_остановки }
                ).Select(a =>
                   new {
                       a.Key.название,
                       a.Key.Адрес,
                       a.Key.время_работы,
                       a.Key.название_остановки,
                       Маршруты = a.Select(mo => new { mo.маршрут, mo.разница }).Distinct().ToArray(),
                       Лекарства = a.Select(lek => new { lek.название_формы, lek.цена }).Distinct().ToArray()
                   })
                .ToArray();
            OrderedDrugs = result;
            IsBusy = false;
            initialized = true;
        }
    }
}
