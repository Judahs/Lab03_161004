using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab03
{
    class Program
    {
        static void Main(string[] args)
        {
            Handler doIt = new Handler();
            //Check for any exceptions
            try
            {
                doIt.GetData();
                doIt.Start();
            }
            //If an exception isnt handle by the program then this will show instead
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("This exeption was not handled in the program.");
                Console.WriteLine("Program exits.");
                Console.ReadKey();
            }
        }
    }
}
