using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurferTech.OA.ServiceContract.Models
{
    public class ProjectQueryResultModel
    {
        public int TotalCount { get; set; }

        public List<ProjectModel> ResultList { get; set; }
    }
}
