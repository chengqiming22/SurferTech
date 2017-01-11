using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurferTech.OA.DataModel.Entites
{
    public class Project : EntityBase
    {
        [StringLength(20)]
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public short Status { get; set; }
        /// <summary>
        /// 合作单位
        /// </summary>
        [StringLength(20)]
        public string Cooperator { get; set; }
        [StringLength(1024)]
        public string Remark { get; set; }
    }
}
