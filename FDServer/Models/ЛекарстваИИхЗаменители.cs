using System;
using System.Collections.Generic;

namespace FDServer
{
    public partial class ЛекарстваИИхЗаменители
    {
        public int IdЛекарство { get; set; }
        public int IdЗаменителя { get; set; }

        public virtual Лекарство IdЗаменителяNavigation { get; set; }
        public virtual Лекарство IdЛекарствоNavigation { get; set; }
    }
}
