using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FDServer
{
    public class GetRoutes_Result
    {
        public string Название { get; set; }
        public string Цена { get; set; }
        public Nullable<int> Разница { get; set; }
        public string Название_лекарства { get; set; }
        public string Название_улицы { get; set; }
        public string Номер_дома { get; set; }
        public string Время_начала_работы { get; set; }
        public string Время_окончания_работы { get; set; }
        public string Название_остановки { get; set; }
        public string Номер_маршрута { get; set; }
        public string Вид_транспорта { get; set; }
        public string Название_формы { get; set; }
        public int Порядок { get; set; }
    }
}
