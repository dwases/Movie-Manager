using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieManager.App.Common;
using MovieManager.Domain.Entity;
using Newtonsoft.Json;

namespace MovieManager.App.Concrete
{
    public class FolderService : BaseService<Folder>
    {
        public List<Folder> folders = new List<Folder>();
        public bool DoesFolderExist(string newName)
        {
            bool flag = false;
            foreach (var folder in folders)
            {
                if (folder.Name == newName)
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }
        public void AddMovie(Movie newMovie, string chosenFolderName, MovieService movieService)
        {
            movieService.Movies.Add(newMovie);
            foreach (var folder in folders)
            {
                if (chosenFolderName == folder.Name)
                {
                    folder.Movies.Add(newMovie);
                    return;
                }
            }
            return;
        }
        public void DisplayFolders()
        {
            foreach (Folder folder in folders) { Console.Write(" " + folder.Name); }
        }
        public void ShowMoviesWithDesc(string FolderName)
        {
            bool flag = false;
            foreach (Folder folder in folders)
            {
                if (FolderName == folder.Name)
                {
                    flag = true;
                    Console.WriteLine("Showing the names and descriptions of all movies in a chosen folder:");
                    foreach(Movie movie in folder.Movies)
                    {
                        Console.WriteLine(movie.Name + " : " + movie.Synopsis);
                    }
                }
            }
            if (flag == false)
            {
                Console.WriteLine("The folder named this way does not exist. Request denied.");
                return;
            }
        }
        void Initialize()
        {
            string tempPath = System.IO.Path.GetTempPath();
            string FILE_NAME = tempPath + @"\Folders.txt";
            if (File.Exists(FILE_NAME))
            {
                string json = File.ReadAllText(FILE_NAME);
                folders = JsonConvert.DeserializeObject<List<Folder>>(json);
            }
        }
        public FolderService()
        {
            Initialize();
        }
        public void UpdateFile()
        {
            string output = JsonConvert.SerializeObject(folders);

            string tempPath = System.IO.Path.GetTempPath();
            string FILE_NAME = tempPath + @"\Folders.txt";
            using StreamWriter sw = new StreamWriter(FILE_NAME);
            using JsonWriter writer = new JsonTextWriter(sw);

            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(writer, folders);
        }
    }
}
