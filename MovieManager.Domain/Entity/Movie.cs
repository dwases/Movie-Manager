using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieManager.Domain.Common;

namespace MovieManager.Domain.Entity
{
    public class Movie : BaseEntity
    {
        //public string Name { get; set; }
        //^implemented by parent class
        public string Synopsis { get; set; }
    }
}
