using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dining_App
{
    class DiningHalls
    {
        private string[] diningHallList;
        public DiningHalls() {
            diningHallList = new string[4] {"Bursley", "Baits", "South Quad", "North Quad"};
        }
        public string[] getDiningHalls()
        {
            return diningHallList;
        }
    }
}
