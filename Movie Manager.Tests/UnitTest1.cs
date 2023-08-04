using FluentAssertions;
using Moq;
using MovieManager;
using MovieManager.Abstract;
using MovieManager.App.Abstract;
using MovieManager.App.Concrete;
using MovieManager.Domain.Entity;

namespace Movie_Manager.Tests
{
    public class UnitTestMovieService
    {
        private Func<object, object> s;

        [Fact]
        public void TestReturnNames()
        {
            //Arrange
            Movie movie = new Movie("movie1", "synopsis1");
            var mock = new Mock<MovieService>();
            List<string> movieNames = new List<string>() {movie.Name};
            var movieService = new MovieService();
            //Act
            movieService.Movies.Add(movie);
            var returnedItem = movieService.ReturnMovieNames();
            //Assert
            returnedItem.Should().NotBeNull();
            returnedItem.Should().NotBeEmpty();
            returnedItem.Should().BeEquivalentTo(movieNames);
        }
    }
    public class UnitTestFolderService
    {
        [Fact]
        public void TestDoesFolderExist()
        {
            //Arrange
            var folderService = new FolderService();
            string newName = "random string";
            folderService.folders.Add(new Folder(newName));
            //Act
            bool returnedItem = folderService.DoesFolderExist(newName);
            //Assert
            returnedItem.Should().BeTrue();
        }
        [Fact]
        public void TestAddMovie()
        {
            //Arrange
            Movie newMovie = new Movie("movie name", "movie synopsis");
            string chosenFolderName = "folder name";
            Folder folder = new Folder(chosenFolderName);
            MovieService movieService = new MovieService();
            FolderService folderService = new FolderService();
            movieService.Movies.Add(newMovie);
            folder.Movies.Add(newMovie);
            folderService.folders.Add(folder);
            MovieService resultMovieService = new MovieService();
            FolderService resultFolderService = new FolderService();
            //Act
            Folder testFolder = new Folder(chosenFolderName);
            resultFolderService.folders.Add(testFolder);
            resultFolderService.AddMovie(newMovie, chosenFolderName, resultMovieService);
            //Assert
            resultFolderService.folders.Should().NotBeNull();
            resultFolderService.folders[0].Should().NotBeNull();
            resultFolderService.folders[0].Should().BeEquivalentTo(testFolder);
            resultFolderService.folders[0].Movies.Should().NotBeNull();
            resultFolderService.folders[0].Movies[0].Should().BeEquivalentTo(newMovie);
            resultMovieService.Movies.Should().NotBeNull();
            resultMovieService.Movies[0].Should().NotBeNull();
            resultMovieService.Movies[0].Should().BeEquivalentTo(newMovie);
        }
    }
    public class UnitTestsMenuMethods
    {
        [Fact]
        public void TestAddFolder()
        {
            //Arrange
            using (var sw = new StringWriter())
            {
                using(var sr = new StringReader("example folder name"))
                {
                    Console.SetOut(sw);
                    Console.SetIn(sr);
                    MenuMethods menuMethods = new MenuMethods();
                    string newFolderName = sr.ReadLine();
                    FolderService folderService = new FolderService();
                    Folder newFolder = new Folder("example folder name");
                    folderService.folders.Add(newFolder);

                    var folderService2 = new FolderService();
                    //Act
                    menuMethods.AddFolder(ref folderService2);
                    var result = sw.ToString();
                    //Assert
                    folderService2.Should().NotBeNull();
                    folderService2.folders[0].Should().NotBeNull();
                    result.Should().NotBeNull();
                    result.Should().BeEquivalentTo("Input a name for the folder you wish to add:\r\nA folder has been added successfully!\r\n");
                }
            }
        }
        [Fact]
        public void TestAddMovieToFolder()
        {
            //Arrange
            using (var sw = new StringWriter())
            {
                using(var sr = new StringReader("chosen folder name\r\nmovie name\r\nmovie synopsis\r\n"))
                {
                    Console.SetOut(sw);
                    Console.SetIn(sr);
                    MenuMethods menuMethods = new MenuMethods();
                    FolderService folderService = new FolderService();
                    MovieService movieService = new MovieService();
                    Folder folder = new Folder("chosen folder name");
                    folderService.folders.Add(folder);
                    //Act
                    menuMethods.AddMovieToFolder(ref folderService, ref movieService);
                    //Assert
                    folderService.folders[0].Should().NotBeNull();
                    folderService.folders[0].Name.Should().BeEquivalentTo("chosen folder name");
                    folderService.folders[0].Movies[0].Should().NotBeNull();
                    folderService.folders[0].Movies[0].Name.Should().NotBeNull();
                    folderService.folders[0].Movies[0].Name.Should().BeEquivalentTo("movie name");
                    folderService.folders[0].Movies[0].Synopsis.Should().BeEquivalentTo("movie synopsis");
                }
            }
        }
    }
}