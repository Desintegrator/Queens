using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8Queen
{
    class Solver
    {
        private ISolvable Solvable;
        private List<string[]> Solutions;


        public Solver(ISolvable solv)
        {
            Solvable = solv;
        }

        public List<string[]> Solve()
        {
            Solutions = Solvable.Solve();
            return Solutions;
        }
    }
}