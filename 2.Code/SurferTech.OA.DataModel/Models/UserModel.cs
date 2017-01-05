using SurferTech.OA.DataModel.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurferTech.OA.DataModel.Models
{
    public class UserModel
    {
        public string UID { get; set; }

        public List<Page> Pages { get; set; }
    }
}
