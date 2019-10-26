using System;
using System.Collections.Generic;

namespace FDServer
{
    public partial class ВидыТранспорта
    {
        public ВидыТранспорта()
        {
            ТранспортныеМаршруты = new HashSet<ТранспортныеМаршруты>();
        }

        public int IdВидаТранспорта { get; set; }
        public string ВидТранспорта { get; set; }

        public virtual ICollection<ТранспортныеМаршруты> ТранспортныеМаршруты { get; set; }
    }
}
