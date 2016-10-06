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
        
        /// <summary>
        /// Creates a list of strings. Loops through all vehicles and first stores the type and
        /// then the name and the speed, separated with semi-colon.
        /// </summary>
        /// <param name="_allVehicles"> A list of all Vehicles from program, of type that implements the IVehicle interface</param>
        /// <returns>A list of strings that can be used in other class/assembly to save the data in a file.</returns>
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
