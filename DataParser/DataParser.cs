using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab03
{
    public class DataParser
    {
        public List<IVehicle> GetVehiclesFromSavedData(List<string> dataRows)
        {
            List <IVehicle> testList = new List<IVehicle>();
            return testList;
        }

        public List<string> CreateDataToSaveFromList(IEnumerable<IVehicle> _allVehicles)
        {
            List<string> stringList = new List<string>();
            foreach (IVehicle currVehicle in _allVehicles)
            {
                string listItem;
                listItem = currVehicle.GetType().Name;      //store the type in string (Car, Boat or Motorcycle).
                listItem += string.Format("; {0}; {1}", currVehicle.Name, currVehicle.GetSpeed());
                stringList.Add(listItem);
            }
            return stringList;
        }
    }
}
