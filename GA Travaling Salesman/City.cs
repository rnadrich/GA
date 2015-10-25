using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA_Travaling_Salesman
{
    class City
    {
       public Tuple<int,int> location=new Tuple<int,int>(0,0);
       public City(int x,int y)
        {
            location = Tuple.Create(x, y);
        }
    }
}
