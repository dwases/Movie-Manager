using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieManager.App.Common;
using MovieManager.Domain.Entity;

namespace MovieManager.App.Concrete
{
    //so far unused
    public class MovieService : BaseService<Movie>
    {
        public List<Movie> Movies = new List<Movie>();
        public List<string> ReturnMovieNames()
        {
            List <string> ret = new List<string>();
            foreach (var movie in Movies)
            {
                ret.Add(movie.Name);
            }
            return ret;
        }
    }
}
