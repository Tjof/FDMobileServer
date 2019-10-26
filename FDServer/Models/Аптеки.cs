using System;
using System.Collections.Generic;

namespace FDServer
{
    public partial class Аптеки
    {
        public Аптеки()
        {
            АссортиментТовара = new HashSet<АссортиментТовара>();
        }

        public int IdАптеки { get; set; }
        public string Название { get; set; }
        public int IdУлицы { get; set; }
        public string НомерДома { get; set; }
        public string ВремяНачалаРаботы { get; set; }
        public string ВремяОкончанияРаботы { get; set; }
        public int IdОстановки { get; set; }

        public virtual Остановки IdОстановкиNavigation { get; set; }
        public virtual Улицы IdУлицыNavigation { get; set; }
        public virtual ICollection<АссортиментТовара> АссортиментТовара { get; set; }
    }
}
