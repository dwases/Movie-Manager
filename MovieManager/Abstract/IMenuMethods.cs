using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieManager.App.Concrete;

namespace MovieManager.Abstract
{
    public interface IMenuMethods
    {
        public void AddFolder(ref FolderService folderService);
        public void AddMovieToFolder(ref FolderService folderService, ref MovieService movieService);
        public void ShowFolderNames(FolderService folderService);
        public void ShowMovies(FolderService folderService);
    }
}
