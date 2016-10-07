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
            List<IVehicle> incomingVehicles = new List<IVehicle>();
            foreach (string row in dataRows)
            { 
                string[] splittedString = row.Split(';');
                if (splittedString.Length >= 3)
                {
                    switch (splittedString[0])  //First column shold contain the type
                    {
                        case "car":             //Uses overloaded constructor to load values from string to IVehicle objects
                            incomingVehicles.Add(new Car(double.Parse(splittedString[2]), splittedString[1]));
                            break;
                        case "boat":
                            incomingVehicles.Add(new Boat(double.Parse(splittedString[2]), splittedString[1]));
                            break;
                        case "motorcycle":
                            incomingVehicles.Add(new Motorcycle(double.Parse(splittedString[2]), splittedString[1]));
                            break;
                        default : throw new Exception("Incorrectly formatted data - wrong type given.");
                    }
                }
                else
                {
                    throw new Exception("Incorrectly formatted data!");
                }
            }
            return incomingVehicles;
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
                listItem = currVehicle.GetType().Name.ToLower();      //store the type in string (car, boat or motorcycle).
                listItem += string.Format(";{0};{1}", currVehicle.Name, currVehicle.GetSpeed());
                stringList.Add(listItem);
            }
            return stringList;
        }
    }
}
