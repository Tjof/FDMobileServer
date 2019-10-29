using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;
using System.Threading.Tasks;

namespace FindDrugMobile
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        bool initialized = false;   // была ли начальная инициализация
        private bool isBusy;    // идет ли загрузка с сервера

        public ObservableCollection<Drugstore> Drugstores { get; set; }
        DrugstoreService drugstoreService = new DrugstoreService();
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

        public ApplicationViewModel()
        {
            Drugstores = new ObservableCollection<Drugstore>();
            IsBusy = false;
        }
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        public async Task GetDrugstores()
        {
            if (initialized == true) return;
            IsBusy = true;
            IEnumerable<Drugstore> drugstores = await drugstoreService.Get();

            //очищаем список
            Drugstores.Clear();
            while (Drugstores.Any())
                Drugstores.RemoveAt(Drugstores.Count - 1);

            // добавляем загруженные данные
            foreach (Drugstore d in drugstores)
                Drugstores.Add(d);
            IsBusy = false;
            initialized = true;
        }
    }
}
