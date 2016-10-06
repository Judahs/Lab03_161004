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
        /// Checks if the files exist or else it will crash during start
        /// if file exist then it will read each line and add it to _allSavedVehicles
        /// if not then it will just return an empty list
        /// </summary>
        /// <returns></returns>
        public List<string> GetSavedData()
        {
            //List<string> _allSavedVehicles = File.ReadLines(@"programdata.csv").ToList();
            List<string> _allSavedVehicles = new List<string>();
            if (!File.Exists(@"programdata.csv"))
            {
                using (StreamReader sr = new StreamReader(@"programdata.csv"))
                {
                    string line = sr.ReadLine();
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
                return _allSavedVehicles;
            }
        }
        public void SaveData(List<string> listOfRowsToSave)
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
