using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurferTech.OA.DataAccess.Dao
{
    public class BaseDao<T> where T : class
    {
        protected OADbContext db = new OADbContext();
    }
}
