using System;
using System.Collections.Generic;

namespace FDServer
{
    public partial class ПользователиОбъекты
    {
        public int IdПользователя { get; set; }
        public int IdОбъекта { get; set; }
        public bool R { get; set; }
        public bool W { get; set; }
        public bool E { get; set; }
        public bool D { get; set; }

        public virtual Объекты IdОбъектаNavigation { get; set; }
        public virtual Пользователи IdПользователяNavigation { get; set; }
    }
}
