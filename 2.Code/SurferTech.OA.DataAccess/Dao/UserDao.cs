using SurferTech.OA.DataModel.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurferTech.OA.DataAccess.Dao
{
    public class UserDao : BaseDao<User>
    {
        public User GetUser(string userName)
        {
            using (var db = new OADbContext())
            {
                var user = db.Users.FirstOrDefault(u => u.UserName == userName && u.IsActive);
                return user;
            }
        }

        public User GetUser(int userId)
        {
            using (var db = new OADbContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Id == userId && u.IsActive);
                return user;
            }
        }
    }
}
