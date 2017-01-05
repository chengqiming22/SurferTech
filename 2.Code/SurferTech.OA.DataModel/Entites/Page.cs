using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurferTech.OA.DataModel.Entites
{
    public class Page
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Group { get; set; }
        public bool IsDefault { get; set; }
    }
}
