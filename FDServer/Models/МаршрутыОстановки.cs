using System;
using System.Collections.Generic;

namespace FDServer
{
    public partial class МаршрутыОстановки
    {
        public int IdМаршрута { get; set; }
        public int IdОстановки { get; set; }
        public int Порядок { get; set; }

        public virtual ТранспортныеМаршруты IdМаршрутаNavigation { get; set; }
        public virtual Остановки IdОстановкиNavigation { get; set; }
    }
}
