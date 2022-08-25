using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flying
{
    public partial class Jupiter
    {
        double M, // гравитационный  параметр  Венеры км3/с2
              R, // радиус Венеры км
              m, // масса КА кг
              Px, // приведенная  нагрузка  на  лобовую  поверхность  КА
              g, // гравитационное ускорение
              r, // расстояние от центра планеты до КА 
              p, // плотность атмосферы 
              p0, // начальная плотность 
              n, // перегрузка
              g0,
              S, // площадь миделя (поперечного сечения) КА м2/кг 
              b, // градиент плотности м-1
              d; // диаметр КА


        private void abc()
        {
            R = 71492;
            M = 1866940.56;

        }

    }
}
