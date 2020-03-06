using System;
using System.Collections.Generic;
using System.Text;

namespace FindDrugMobile
{
    public class Drugstore
    {
        public string название { get; set; }
        public string цена { get; set; }
        public int разница { get; set; }
        public string название_лекарства { get; set; }
        public string название_улицы { get; set; }
        public string номер_дома { get; set; }
        public string время_начала_работы { get; set; }
        public string время_окончания_работы { get; set; }
        public string название_остановки { get; set; }
        public string номер_маршрута { get; set; }
        public string вид_транспорта { get; set; }
        public string название_формы { get; set; }
        public int порядок { get; set; }
        public string Адрес { get => "Адрес: " + название_улицы + " " + номер_дома; }
        public string время_работы { get => время_начала_работы + " - " + время_окончания_работы; }
        public string маршрут { get => "Маршрут: " + номер_маршрута + " " + вид_транспорта; }
    }
}
