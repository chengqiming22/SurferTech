using SurferTech.OA.DataModel.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurferTech.OA.DataAccess.Dao
{
    public class ProjectDao : BaseDao<Project>
    {
        public List<Project> Get(int pageSize, int pageNo, out int totalCount)
        {
            using (var db = new OADbContext())
            {
                totalCount = db.Projects.Count();
                var list = db.Projects.OrderBy(p=>p.Id).Skip(pageSize * (pageNo - 1)).Take(pageSize).ToList();
                return list;
            }
        }
    }
}
