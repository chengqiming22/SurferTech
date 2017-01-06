using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurferTech.OA.ServiceContract.Models
{
    public class UserModel
    {
        public string UID { get; set; }

        public List<PageGroupModel> PageGroups { get; set; }
    }
}
