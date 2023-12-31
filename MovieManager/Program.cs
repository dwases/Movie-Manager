﻿using MovieManager;
using MovieManager.App.Concrete;
using MovieManager.Domain.Entity;
//data
int choice = 0;
FolderService folderService = new FolderService();
MovieService movieService = new MovieService();
MenuMethods MenuMethodsInvoker = new MenuMethods();

//Main Menu
while (true)
{
    Console.WriteLine("\n----------------MovieManager----------------");
    Console.WriteLine("Input your desired action as a whole number:");
    Console.WriteLine("1. Add a new folder for your movies");
    Console.WriteLine("2. Add a new movie to an existing folder");
    Console.WriteLine("3. Show all existing folder names");
    Console.WriteLine("4. Show movie list in a chosen folder");
    Console.WriteLine("5. Display the names of all movies on the platform");
    Console.WriteLine("6. Exit MovieManager");
    choice = Convert.ToInt32(Console.ReadLine());
    switch (choice)
    {
        case 1:
            MenuMethodsInvoker.AddFolder(ref folderService);
            break;
        case 2:
            MenuMethodsInvoker.AddMovieToFolder(ref folderService, ref movieService);
            break;
        case 3:
            MenuMethodsInvoker.ShowFolderNames(folderService);
            break;
        case 4:
            MenuMethodsInvoker.ShowMovies(folderService);
            break;
        case 5:
            MenuMethodsInvoker.ShowAllMovies(movieService);
            break;
        case 6:
            System.Environment.Exit(0);
            break;
        default:
            Console.WriteLine("INVALID COMMAND!");
            break;
    }
}