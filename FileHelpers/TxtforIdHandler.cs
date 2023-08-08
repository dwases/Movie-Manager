using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileHelpers
{
    public class TxtforIdHandler
    {
        public static void GenerateTxtIfNonExistant()
        {
            if(!File.Exists(@"C:DataFiles\IdFile.txt"))
            {
                StreamWriter sw = new StreamWriter(@"C:DataFiles\IdFile.txt", false);
                //id of movie
                sw.WriteLine("0");
                //id of folder
                sw.WriteLine("0");
                sw.Close();
            }
        }
    }
}
