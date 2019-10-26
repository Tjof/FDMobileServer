using System;
using System.Collections.Generic;

namespace FDServer
{
    public partial class Лекарство
    {
        public Лекарство()
        {
            АссортиментТовара = new HashSet<АссортиментТовара>();
            ЛекарстваИИхЗаменителиIdЗаменителяNavigation = new HashSet<ЛекарстваИИхЗаменители>();
            ЛекарстваИИхЗаменителиIdЛекарствоNavigation = new HashSet<ЛекарстваИИхЗаменители>();
        }

        public int IdЛекарство { get; set; }
        public string НазваниеЛекарства { get; set; }

        public virtual ICollection<АссортиментТовара> АссортиментТовара { get; set; }
        public virtual ICollection<ЛекарстваИИхЗаменители> ЛекарстваИИхЗаменителиIdЗаменителяNavigation { get; set; }
        public virtual ICollection<ЛекарстваИИхЗаменители> ЛекарстваИИхЗаменителиIdЛекарствоNavigation { get; set; }
    }
}
