using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieManager.App.Concrete;
using MovieManager.Domain.Entity;

namespace MovieManager
{
    public class MenuMethods
    {
        //for choice #1
        //public void AddFolder(ref List <Folder> AllFolders)
        public void AddFolder(ref FolderService folderService)
        {
            Console.WriteLine("Input a name for the folder you wish to add:");
            string new_folder_name = Console.ReadLine(); 
            /*
            foreach (Folder folder in AllFolders)
            {
                if(new_folder_name == folder.Name)
                {
                    Console.WriteLine("SUCH A FOLDER ALREADY EXISTS, REQUEST DENIED!");
                    return;
                }
            }
            */
            if(folderService.DoesFolderExist(new_folder_name))
            {
                Console.WriteLine("SUCH A FOLDER ALREADY EXISTS, REQUEST DENIED!");
                return;
            }
            else
            {
                Folder NewFolder = new Folder(new_folder_name);
                //NewFolder.Name = new_folder_name;
                folderService.folders.Add(NewFolder);
            }
            /*
            Folder NewFolder = new Folder();
            NewFolder.Name = new_folder_name;
            AllFolders.Add(NewFolder);
            */

            //
            Console.WriteLine("A folder has been added successfully!");
            return;
        }
        //for choice #2
        //public void AddMovieToFolder(ref List <Folder> AllFolders)
        public void AddMovieToFolder(ref FolderService folderService, ref MovieService movieService)
        {
            Console.WriteLine("Input the name of the folder you wish to add your movie to:");
            string chosen_folder_name = Console.ReadLine();
            /*
            bool flag = false;
            foreach (Folder folder in AllFolders)
            {
                if (chosen_folder_name == folder.Name)
                {
                    flag = true;
                    Console.WriteLine("Input the name of the movie you wish to add to the folder:");
                    string movie_name = Console.ReadLine();
                    Console.WriteLine("Input the synopsis of the movie you wish to add to the folder:");
                    string movie_synopsis = Console.ReadLine();
                    Movie new_movie = new Movie();
                    new_movie.Name = movie_name;
                    new_movie.Synopsis = movie_synopsis;
                    folder.Movies.Add(new_movie);
                    break;
                }
            }
            if (flag == false)
            {
                Console.WriteLine("The folder named this way does not exist. Request denied.");
                return;
            }
            */
            if(folderService.DoesFolderExist(chosen_folder_name))
            {
                Console.WriteLine("Input the name of the movie you wish to add to the folder:");
                string movie_name = Console.ReadLine();
                Console.WriteLine("Input the synopsis of the movie you wish to add to the folder:");
                string movie_synopsis = Console.ReadLine();
                Movie new_movie = new Movie(movie_name, movie_synopsis);
                //new_movie.Name = movie_name;
                //new_movie.Synopsis = movie_synopsis;
                folderService.AddMovie(new_movie, chosen_folder_name);
                movieService.AddMovie(new_movie);
                //folder.Movies.Add(new_movie);
            }
            else
            {
                Console.WriteLine("The folder named this way does not exist. Request denied.");
                return;
            }
        }
        //for choice #3
        //public void ShowFolderNames(List<Folder> AllFolders)
        public void ShowFolderNames(FolderService folderService)
        {
            Console.WriteLine("Showing the names of all folders:");
            Console.WriteLine("---------------------------------");
            //foreach (Folder folder in AllFolders) { Console.Write(" " + folder.Name); }
            folderService.DisplayFolders();
            Console.WriteLine("\n---------------------------------");
        }
        //for choice #4
        //public void ShowMovies(List<Folder> AllFolders)
        public void ShowMovies(FolderService folderService)
        {
            Console.WriteLine("Input the name of the folder where the desired movies are kept:");
            string folder_name = Console.ReadLine();
            
            folderService.ShowMoviesWithDesc(folder_name);
            /*
            bool flag = false;
            foreach (Folder folder in AllFolders)
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
            */
        }
        //for choice #5
        public void ShowAllMovies(MovieService movieService)
        {
            Console.WriteLine("Wykaz nazw wszystkich filmów obsługiwanych przez platformę:");
            Console.Write(" | ");
            foreach(string st in movieService.ReturnMovieNames())
            {
                Console.Write(st + " | ");
            }
            Console.WriteLine();
        }
    }
}
