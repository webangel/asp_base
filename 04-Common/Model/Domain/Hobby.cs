using Common.CustomFilters;
using Model.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    public class Hobby: AuditEntity, ISoftDeleted
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public bool Deleted { get; set; }
    }
}
