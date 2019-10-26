using System;
using System.Collections.Generic;

namespace FDServer
{
    public partial class Объекты
    {
        public Объекты()
        {
            ПользователиОбъекты = new HashSet<ПользователиОбъекты>();
        }

        public int IdОбъекта { get; set; }
        public string ИмяОбъекта { get; set; }

        public virtual ICollection<ПользователиОбъекты> ПользователиОбъекты { get; set; }
    }
}
