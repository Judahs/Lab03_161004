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
        public List<string> GetSavedData()
        {
            List<string> dataList = new List<string>();

            using (StreamReader sr = new StreamReader(@"programdata.csv"))
            {
                string line = sr.ReadLine();
                while (line != null)
                {
                    dataList.Add(line);     //Read from file, add rows as long as possible
                    line = sr.ReadLine();
                }
            }
            return dataList;
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
