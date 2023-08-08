using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieManager.App.Common;
using MovieManager.Domain.Entity;
using System.Linq;
using System.Xml.Serialization;
using System.IO;
using Newtonsoft.Json;

namespace MovieManager.App.Concrete
{
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
        private void Initialize()
        {
            string tempPath = System.IO.Path.GetTempPath();
            string FILE_NAME = tempPath + @"\Movies.txt";
            if (File.Exists(FILE_NAME))
            {
                string json = File.ReadAllText(FILE_NAME);
                Movies = JsonConvert.DeserializeObject<List<Movie>>(json);
            }
        }
        public MovieService()
        {
            Initialize();
        }
        public void UpdateFile()
        {
            string output = JsonConvert.SerializeObject(Movies);

            string tempPath = System.IO.Path.GetTempPath();
            string FILE_NAME = tempPath + @"\Movies.txt";
            using StreamWriter sw = new StreamWriter(FILE_NAME);
            using JsonWriter writer = new JsonTextWriter(sw);

            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(writer, Movies);
        }
    }
}
