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
        public static List<string> GetSavedData()
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

        public static void SaveData(List<string> listOfRowsToSave)
        {
            using (StreamWriter sw = new StreamWriter(@"programdata.csv"))
            {
                for (int i = 0; i < listOfRowsToSave.Count; i++)
                    sw.WriteLine(listOfRowsToSave[i]);
            }
        }
    }
}
