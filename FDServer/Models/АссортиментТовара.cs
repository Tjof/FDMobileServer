using System;
using System.Collections.Generic;

namespace FDServer
{
    public partial class АссортиментТовара
    {
        public int IdЛекарство { get; set; }
        public int IdАптеки { get; set; }
        public string Количество { get; set; }
        public int IdФормыУпаковки { get; set; }
        public string Цена { get; set; }

        public virtual Аптеки IdАптекиNavigation { get; set; }
        public virtual Лекарство IdЛекарствоNavigation { get; set; }
        public virtual ФормыУпаковки IdФормыУпаковкиNavigation { get; set; }
    }
}
