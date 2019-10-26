using System;
using System.Collections.Generic;

namespace FDServer
{
    public partial class Пользователи
    {
        public Пользователи()
        {
            ПользователиОбъекты = new HashSet<ПользователиОбъекты>();
        }

        public int IdПользователя { get; set; }
        public string Login { get; set; }
        public string Pass { get; set; }

        public virtual ICollection<ПользователиОбъекты> ПользователиОбъекты { get; set; }
    }
}
