using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechChallenge.Utils
{

    public class Constants
    {
        public Constants()
        {

        }
        private readonly string mockarooEndPoint = "https://my.api.mockaroo.com/data.json?key=e8b26050";
        public string MockarooEndPoint { get {return mockarooEndPoint; } }

    }
}
