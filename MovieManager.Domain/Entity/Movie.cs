using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieManager.Domain.Common;
using System.Xml.Serialization;

namespace MovieManager.Domain.Entity
{
    public class Movie : BaseEntity
    {
        public string Synopsis { get; set; }
        public Movie(string name, string synopsis)
        {
            Name = name;
            Synopsis = synopsis;
        }
    }
}
