using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieManager.Abstract;
using MovieManager.App.Concrete;
using MovieManager.Domain.Entity;

namespace MovieManager
{
    public class MenuMethods : IMenuMethods
    {
        //for choice #1
        public void AddFolder(ref FolderService folderService)
        {
            Console.WriteLine("Input a name for the folder you wish to add:");
            string newFolderName = Console.ReadLine(); 
            if(folderService.DoesFolderExist(newFolderName))
            {
                Console.WriteLine("SUCH A FOLDER ALREADY EXISTS, REQUEST DENIED!");
                return;
            }
            else
            {
                Folder NewFolder = new Folder(newFolderName);
                folderService.folders.Add(NewFolder);
            }
            Console.WriteLine("A folder has been added successfully!");
            return;
        }
        //for choice #2
        public void AddMovieToFolder(ref FolderService folderService, ref MovieService movieService)
        {
            Console.WriteLine("Input the name of the folder you wish to add your movie to:");
            string chosenFolderName = Console.ReadLine();
            if(folderService.DoesFolderExist(chosenFolderName))
            {
                Console.WriteLine("Input the name of the movie you wish to add to the folder:");
                string movieName = Console.ReadLine();
                Console.WriteLine("Input the synopsis of the movie you wish to add to the folder:");
                string movieSynopsis = Console.ReadLine();
                Movie newMovie = new Movie(movieName, movieSynopsis);
                folderService.AddMovie(newMovie, chosenFolderName, movieService);
            }
            else
            {
                Console.WriteLine("The folder named this way does not exist. Request denied.");
                return;
            }
        }
        //for choice #3
        public void ShowFolderNames(FolderService folderService)
        {
            Console.WriteLine("Showing the names of all folders:");
            Console.WriteLine("---------------------------------");
            folderService.DisplayFolders();
            Console.WriteLine("\n---------------------------------");
        }
        //for choice #4
        public void ShowMovies(FolderService folderService)
        {
            Console.WriteLine("Input the name of the folder where the desired movies are kept:");
            string folderName = Console.ReadLine();
            
            folderService.ShowMoviesWithDesc(folderName);
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
