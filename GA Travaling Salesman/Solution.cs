using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA_Travaling_Salesman
{
    class Solution : IEquatable<Solution>, IComparable<Solution>
    {
        public List<City> genome=new List<City>(); //also the phenotype
        public double fitness;

        public Solution()
        {
            RandomizeGenome();
            fitness = 0.0;
        }
        // Default comparer Solution (higher fitness on top)
        public int CompareTo(Solution compareSol)
        {
            // A null value means that this object is smaller.
            if (compareSol == null)
                return -1;

            else
                return compareSol.fitness.CompareTo(this.fitness);
        }
        public bool Equals(Solution other)
        {
            if (other == null) return false;
            return (this.fitness.Equals(other.fitness));
        }

        private void RandomizeGenome()
        {
            //genome = "";
            for (int i = 0; i < G.target_size; i++)
            {
               // genome += G.randChar();
                int index=G.rand(G.target_size);
                City temp = Population.CitiesToVisit[index];
                genome.Add(temp);
            }
        }

        static public bool operator <(Solution rhs, Solution lhs)
        {
            return rhs.fitness < lhs.fitness;
        }

        static public bool operator >(Solution rhs, Solution lhs)
        {
            return rhs.fitness > lhs.fitness;
        }



        public void Mutate()
        {
            List<City> s= new List<City>();
            foreach (City c in genome)
            {
                if (G.chance(G.probabilityOfCharMutation))
                {
                    s.Add(Population.CitiesToVisit[G.rand(G.target_size)]);
                }
                else 
                {
                    s.Add(c);
                }
            }
            genome = s;
            Problem.Evaluate(this);
        }

        public string displayString
        {
            get
            {
                string s = "";
                int count = 0;
                foreach (City c in genome)
                {
                    s += count + ":" + genome[count].location.ToString()+"\n\r";
                    count++;
                }
                return s;
            }
        }

    
    
    
    
    
    }
}
