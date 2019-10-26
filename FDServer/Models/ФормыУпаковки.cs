using System;
using System.Collections.Generic;

namespace FDServer
{
    public partial class ФормыУпаковки
    {
        public ФормыУпаковки()
        {
            АссортиментТовара = new HashSet<АссортиментТовара>();
        }

        public int IdФормыУпаковки { get; set; }
        public string НазваниеФормы { get; set; }

        public virtual ICollection<АссортиментТовара> АссортиментТовара { get; set; }
    }
}
