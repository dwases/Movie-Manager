using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManager.App.Abstract
{
    public interface IService<T>
    {
        List<T> Elements { get; set; }
        void ReturnNames(T obj);
    }
}
