using System;
using System.Collections.Generic;

namespace FDServer
{
    public partial class Остановки
    {
        public Остановки()
        {
            Аптеки = new HashSet<Аптеки>();
            МаршрутыОстановки = new HashSet<МаршрутыОстановки>();
        }

        public int IdОстановки { get; set; }
        public int IdУлицы { get; set; }
        public string НазваниеОстановки { get; set; }

        public virtual Улицы IdУлицыNavigation { get; set; }
        public virtual ICollection<Аптеки> Аптеки { get; set; }
        public virtual ICollection<МаршрутыОстановки> МаршрутыОстановки { get; set; }
    }
}
