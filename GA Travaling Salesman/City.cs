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
        public double distanceTo(City c)
       {
           double dist = 0;
           int difX = this.location.Item1 - c.location.Item1;
           int difY = this.location.Item2 - c.location.Item2;
           dist = Math.Sqrt(difX * difX + difY * difY);
           return dist;
       }
    }
}
