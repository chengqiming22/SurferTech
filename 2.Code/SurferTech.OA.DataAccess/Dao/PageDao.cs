using SurferTech.OA.DataModel.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurferTech.OA.DataAccess.Dao
{
    public class PageDao:BaseDao<Page>
    {
        public List<Page> GetPagesByUserName(string userName)
        {
            using (var db = new OADbContext())
            {
                var user = db.Users.Include("Roles").FirstOrDefault(u => u.UserName == userName);
                if (user == null)
                    return null;
                var pageIds = new List<long>();
                foreach (var role in user.Roles)
                {
                    db.Entry(role).Collection(r => r.Permissions).Load();
                    pageIds.AddRange(db.Permissions.Select(p => p.ResourceId));
                }
                pageIds = pageIds.Distinct().ToList();
                var pages = db.Pages.Include("Group").Where(p => pageIds.Contains(p.Id)).ToList();
                return pages;
            }
        }
    }
}
