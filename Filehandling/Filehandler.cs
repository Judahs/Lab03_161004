using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lab03
{
    public class Filehandler
    {
        /// <summary>
        /// Checks if the files exist or else it will throw exeption during start
        /// If file exist then it will read each line and add it to _allVehicles
        /// If file is empty an other exeption will be thrown
        /// </summary>
        /// <returns></returns>
        public List<string> GetSavedData()
        {
            //List<string> _allSavedVehicles = File.ReadLines(@"programdata.csv").ToList();
            List<string> _allSavedVehicles = new List<string>();
            if (File.Exists(@"programdata.csv"))
            {
                using (StreamReader sr = new StreamReader(@"programdata.csv"))
                {
                    string line = sr.ReadLine();
                    if (line == null)
                        throw new Exception("Data file is empty.");
                    while (line != null)
                    {
                        _allSavedVehicles.Add(line);     //Read from file, add rows as long as possible
                        line = sr.ReadLine();
                    }
                }
                return _allSavedVehicles;
            }
            else
            {
                throw new Exception("No data file found.");
            }
        }
        /// <summary>
        /// Opens a file and writes the data so it from a list of strings.
        /// </summary>
        /// <param name="listOfRowsToSave">Data parsed from vehicle objects</param>
        public void WriteToFile(List<string> listOfRowsToSave)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(@"programdata.csv"))
                {
                    foreach (string item in listOfRowsToSave)
                        sw.WriteLine(item);
                }
            }
            catch (Exception)
            {
                throw new Exception ("Could not save data to programdata.csv - the file may be read-only or used in another program.");
            }

        }
    }
}
