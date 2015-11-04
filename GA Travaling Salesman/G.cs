using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA_Travaling_Salesman
{
    public static class G
    {
        static Random random = new Random();

        static public int rand(int Emax)
        {
            return random.Next(Emax);
        }

        static public char randChar()
        {
            return (char)rand(128);
        }

        static public int population_size = 200;
        public static double probabilityOfSolutionMutation = 0.1;
        public static double probabilityOfCharMutation = .01;
        public static int target_size = 100;
        public static bool chance(double p)
        {
            return G.random.NextDouble() < p;
        }



    
    }
}
