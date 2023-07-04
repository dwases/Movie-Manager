using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManager.Domain.Common
{
    public class BaseEntity : AuditableModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
