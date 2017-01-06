using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurferTech.OA.ServiceContract.Models
{
    public class PageGroupModel
    {
        public string Name { get; set; }

        public PageModel DefaultPage { get; set; }

        public List<PageModel> Pages { get; set; }
    }
}
