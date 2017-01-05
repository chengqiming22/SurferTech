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
        public User GetUser(string uid,string pwd)
        {
            var user = db.Users.FirstOrDefault(u => u.UID == uid && u.Password == pwd && u.IsActive);
            return user;
        }
    }
}
