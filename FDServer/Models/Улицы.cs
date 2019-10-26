using System;
using System.Collections.Generic;

namespace FDServer
{
    public partial class Улицы
    {
        public Улицы()
        {
            Аптеки = new HashSet<Аптеки>();
            Остановки = new HashSet<Остановки>();
        }

        public int IdУлицы { get; set; }
        public string НазваниеУлицы { get; set; }

        public virtual ICollection<Аптеки> Аптеки { get; set; }
        public virtual ICollection<Остановки> Остановки { get; set; }
    }
}
