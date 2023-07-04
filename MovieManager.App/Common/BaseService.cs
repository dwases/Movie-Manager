using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieManager.App.Abstract;
using MovieManager.Domain.Common;
using MovieManager.Domain.Entity;

namespace MovieManager.App.Common
{
    public class BaseService<T> : IService<T> where T : BaseEntity
    {
        public List<T> Elements { get; set; }

        public void ReturnNames(T obj)
        {
            foreach (var item in Elements)
            {
                Console.Write(" " + item.Name);
            }
        }
    }
}
