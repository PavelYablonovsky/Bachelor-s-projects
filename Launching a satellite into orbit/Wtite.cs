using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Flying
{
    public class  Wtite
    {

        public static string WritetoFileAppend(string res)
        {
            using (StreamWriter str = new StreamWriter("calculations.txt", true))
            {
                str.WriteLine(res + "\n");
        
            }

              return res;


        }

        public static string WritetoFile(string res)
        {
            using (StreamWriter str = new StreamWriter("calculations.txt"))
            {
                str.WriteLine(res + "\n");

            }

            return res;


        }


    }
}
