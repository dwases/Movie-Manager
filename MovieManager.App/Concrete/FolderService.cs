using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieManager.App.Common;
using MovieManager.Domain.Entity;

namespace MovieManager.App.Concrete
{
    public class FolderService : BaseService<Folder>
    {
        public List<Folder> folders = new List<Folder>();
        //public List<Folder> folders;

        //testing grounds
        public bool DoesFolderExist(string new_name)
        {
            bool flag = false;
            foreach (var folder in folders)
            {
                if (folder.Name == new_name)
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }
        public void AddMovie(Movie new_movie, string chosen_folder_name)
        {
            foreach (var folder in folders)
            {
                if (chosen_folder_name == folder.Name)
                {
                    folder.Movies.Add(new_movie);
                    return;
                }
            }
            return;
        }
        public void DisplayFolders()
        {
            foreach (Folder folder in folders) { Console.Write(" " + folder.Name); }
        }
        public void ShowMoviesWithDesc(string folder_name)
        {
            bool flag = false;
            foreach (Folder folder in folders)
            {
                if (folder_name == folder.Name)
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
    }
}
