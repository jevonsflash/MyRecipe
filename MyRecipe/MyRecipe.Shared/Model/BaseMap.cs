using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipe.Model
{
    public class BaseMap
    {
        public BaseMap()
        {

        }
        public string description { get; set; }
        public int id { get; set; }
        public string keywords { get; set; }
        public string name { get; set; }
        public int seq { get; set; }
        public string title { get; set; }
    }
}
