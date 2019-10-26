using System;
using System.Collections.Generic;

namespace FDServer
{
    public partial class ТранспортныеМаршруты
    {
        public ТранспортныеМаршруты()
        {
            МаршрутыОстановки = new HashSet<МаршрутыОстановки>();
        }

        public int IdМаршрута { get; set; }
        public string НомерМаршрута { get; set; }
        public int IdВидаТранспорта { get; set; }

        public virtual ВидыТранспорта IdВидаТранспортаNavigation { get; set; }
        public virtual ICollection<МаршрутыОстановки> МаршрутыОстановки { get; set; }
    }
}
