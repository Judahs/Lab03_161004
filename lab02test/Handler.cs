using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab03
{
    class Handler
    {
        private VehicleType _baseChoice;
        private int _numbOfVehicleChoice;
        private double _newSpeed;
        private List<Car> _cars;
        private List<Boat> _boats;
        private List<Motorcycle> _motorcycles;
        private List<IVehicle> _allVehicles;

        public Handler()
        {
            //Creates a list for respective vehicle
            _cars = new List<Car>();
            _boats = new List<Boat>();
            _motorcycles = new List<Motorcycle>();
        }
        /// <summary>
        /// Simple function to print the menu, user can only advance in the menu by inputing 1,2,3,4 or 0
        /// </summary>
        static private void PrintBaseMenu()
        {
            Console.Clear();
            Console.WriteLine("--Please select--");
            Console.WriteLine("1. Print/Create cars");
            Console.WriteLine("2. Print/Create boats");
            Console.WriteLine("3. Print/Create motorcycles");
            Console.WriteLine("4. Print all vehicles in m/s");
            Console.WriteLine("Enter 0 to exit program.");
        }
        private void SetMenuChoice()
        {
            bool parseTest = false;
            int input;
            parseTest = int.TryParse(Console.ReadLine(), out input);
            //Check if user input is between 0-4, throws exception if true
            while (!parseTest || (input < 0 || input > 4))
            {
                Console.WriteLine("Incorrect input, please try again.");
                PrintBaseMenu();
                parseTest = int.TryParse(Console.ReadLine(), out input);
            }
            //Casts intiger value from input to Choice Enum type
            _baseChoice = (VehicleType)input;
        }
        private void PrintListOfVehicle()
        {
            //If there is no vehicle in 1-2-3 the the user will only be prompted to add a vehicle
            //When a vehicle in the picked list then it the list will be prined and the user will be prompted to chose 1-9 or add vehicle with +
            switch (_baseChoice)
            {
                case VehicleType.car:
                    if (_cars.Count == 0)
                    {
                        Console.WriteLine("Car stock is empty");
                        Console.WriteLine("Enter + to add a new car");
                    }
                    else if (_cars.Count > 0)
                    {
                        for (int i = 0; i < _cars.Count; i++)
                            Console.WriteLine("Car {0}, name: {1} – {2} mph", i, _cars[i].Name, _cars[i].GetSpeed());
                        Console.WriteLine("Please select car to change (0-9) or enter + to add a new car");
                    }
                    break;
                case VehicleType.boat:
                    if (_boats.Count == 0)
                    {
                        Console.WriteLine("Boat stock is empty");
                        Console.WriteLine("Enter + to add a new Boat");
                    }
                    else if (_boats.Count > 0)
                    {
                        for (int i = 0; i < _boats.Count; i++)
                            Console.WriteLine("Boat {0}, name: {1} – {2} knot", i, _boats[i].Name, _boats[i].GetSpeed());
                        Console.WriteLine("Please select boat to change (0-9) or enter + to add a new boat");
                    }
                    break;
                case VehicleType.motorcycle:
                    if (_motorcycles.Count == 0)
                    {
                        Console.WriteLine("Motorcycle stock is empty");
                        Console.WriteLine("Enter + to add a new motorcycle");
                    }
                    else if (_motorcycles.Count > 0)
                    {
                        for (int i = 0; i < _motorcycles.Count; i++)
                            Console.WriteLine("Motorcycle {0}, name: {1} – {2} km/h", i, _motorcycles[i].Name, _motorcycles[i].GetSpeed());
                        Console.WriteLine("Please select motorcycle to change (0-9) or enter + to add a new motorcycle");
                    }
                    break;
            }
            string userInput = Console.ReadLine();
            //if user gave "+" _currentState sets to -1
            if (userInput == "+") 
                _numbOfVehicleChoice = -1;
            else
            {
                bool parseTest = false;
                parseTest = int.TryParse(userInput, out _numbOfVehicleChoice);
                //Check if user input is below 0 or above 9, throws exception if true
                while (!parseTest || (_numbOfVehicleChoice < 0 || _numbOfVehicleChoice > 9))
                {
                    Console.WriteLine("Incorrect input, please try again.");
                    userInput = Console.ReadLine();
                    if (userInput == "+")
                    {
                        _numbOfVehicleChoice = -1;
                        break;
                    }
                    parseTest = int.TryParse(userInput, out _numbOfVehicleChoice);
                }
            }
        }
        private void AddVehicle()
        {
            switch (_baseChoice)
            {
                case VehicleType.car:
                    //We made a small garage to only hold 10 of each vehicle type, program will tell when there are more then 10 vehicle in respective list
                    if (_cars.Count < 10)
                    { 
                        _cars.Add(new Car());
                        Console.WriteLine("Car added ({0} mph, name: {1}), press any key to go back to main menu.", _cars.Last().GetSpeed(), _cars.Last().Name);
                    }
                    else
                        Console.WriteLine("Car stock is full! Press any key to go back to main menu.");
                    break;
                case VehicleType.boat:
                    if (_boats.Count < 10)
                    {
                        _boats.Add(new Boat());
                        Console.WriteLine("Boat added ({0} knots, name: {1}), press any key to go back to main menu.", _boats.Last().GetSpeed(), _boats.Last().Name);
                    }
                    else
                        Console.WriteLine("Boat stock is full! Press any key to go back to main menu.");
                    break;
                case VehicleType.motorcycle:
                    if (_motorcycles.Count < 10)
                    {
                        _motorcycles.Add(new Motorcycle());
                        Console.WriteLine("Motorcycle added ({0} km/h, name: {1}), press any key to go back to main menu.", _motorcycles.Last().GetSpeed(), _motorcycles.Last().Name);
                    }
                    else
                        Console.WriteLine("Motorcycle stock is full! Press any key to go back to main menu.");
                    break;
                default:
                    break;
            }
            Console.ReadKey();
        }
        private void ChosenVehicleInfoMenu()
        {
            switch (_baseChoice)
            {
                case VehicleType.car:
                    Console.WriteLine("-- Car {0} --", _numbOfVehicleChoice);
                    //When trying to access a none existing vehicle a exception will be thrown
                    try
                    {
                        Console.WriteLine("Speed: {0} mph", _cars[_numbOfVehicleChoice].GetSpeed());
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        throw new ArgumentOutOfRangeException("Position in list","No car in that postition");
                    }
                    Console.WriteLine("Please enter new speed(0 - 100) or – to remove car");
                    break;
                case VehicleType.boat:
                    Console.WriteLine("-- Boat {0} --", _numbOfVehicleChoice);
                    try
                    {
                        Console.WriteLine("Speed: {0} knots", _boats[_numbOfVehicleChoice].GetSpeed());
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        throw new ArgumentOutOfRangeException("Position in list", "No boat in that postition");
                    }
                    Console.WriteLine("Please enter new speed(0 - 100) or – to remove boat");
                    break;
                case VehicleType.motorcycle:
                    Console.WriteLine("-- Motorcycle {0} --");
                    try
                    {
                        Console.WriteLine("Speed: {0} km/h", _motorcycles[_numbOfVehicleChoice].GetSpeed());
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        throw new ArgumentOutOfRangeException("Position in list", "No motorcycle in that postition");
                    }
                    Console.WriteLine("Please enter new speed(0 - 100) or – to remove motorcycle");
                    break;
            }
            string userInput = Console.ReadLine();
            //If user gave "-" _newSpeed sets to -1
            if (userInput == "-")                       
                _newSpeed = -1;
            else
            {
                bool parseTest = false;
                parseTest = double.TryParse(userInput, out _newSpeed);
                //Check if user input is below 0 or above 100, throws exception if true
                while (!parseTest || (_newSpeed < 0 || _newSpeed > 100))   
                {
                    Console.WriteLine("Incorrect input, please try again.");
                    userInput = Console.ReadLine();
                    if (userInput == "-")
                    {
                        _newSpeed = -1;
                        break;
                    }
                    parseTest = double.TryParse(userInput, out _newSpeed);
                }
            }
        }
        private void RemoveVehicle()
        {
            //If vehicle was succesfully removed then this will be shown
            switch (_baseChoice)
            {
                case VehicleType.car:
                    _cars.RemoveAt(_numbOfVehicleChoice);
                    Console.WriteLine("Car removed, press any key to go back to main menu");
                    break;
                case VehicleType.boat:
                    _boats.RemoveAt(_numbOfVehicleChoice);
                    Console.WriteLine("Boat removed, press any key to go back to main menu");
                    break;
                case VehicleType.motorcycle:
                    _motorcycles.RemoveAt(_numbOfVehicleChoice);
                    Console.WriteLine("Motorcycle removed, press any key to go back to main menu");
                    break;
            }
            Console.ReadKey();
        }
        private void ChangeVehicle()
        {
            //Will be showen when a speed of a vehicle type have been changed
            switch (_baseChoice)
            {
                case VehicleType.car:
                    _cars[_numbOfVehicleChoice].SetSpeed(_newSpeed);
                    Console.Write("Car {0} speed changed to {1}, ", _numbOfVehicleChoice, _cars[_numbOfVehicleChoice].GetSpeed());
                    break;
                case VehicleType.boat:
                    _boats[_numbOfVehicleChoice].SetSpeed(_newSpeed);
                    Console.Write("Boat {0} speed changed to {1}, ", _numbOfVehicleChoice, _boats[_numbOfVehicleChoice].GetSpeed());
                    break;
                case VehicleType.motorcycle:
                    _motorcycles[_numbOfVehicleChoice].SetSpeed(_newSpeed);
                    Console.Write("Motorcycle {0} speed changed to {1}, ", _numbOfVehicleChoice, _motorcycles[_numbOfVehicleChoice].GetSpeed());
                    break;
            }
            Console.WriteLine("press any key to go back to main menu");
            Console.ReadKey();
        }
        //Print all vehicles in all 3 lists and calculates each vehicles M/S
        private void PrintMsList()
        {
            int counter = 0;
            Console.WriteLine("\n--{0} cars in stock--", _cars.Count);
            foreach (Car thisCar in _cars)
            {
                Console.Write("Car {0} – ", counter);
                PrintSpeedInMetersPerSecond(thisCar);
                Console.WriteLine(" m/s");
                counter++;
            }
            counter = 0;
            Console.WriteLine("\n--{0} boats in stock--", _boats.Count);
            foreach (Boat thisBoat in _boats)
            {
                Console.Write("Boat {0} – ", counter);
                PrintSpeedInMetersPerSecond(thisBoat);
                Console.WriteLine(" m/s");
                counter++;
            }
            counter = 0;
            Console.WriteLine("\n--{0} motorcycles in stock--", _motorcycles.Count);
            foreach (Motorcycle thisMotorcycle in _motorcycles)
            {
                Console.Write("Motorcycle {0} – ", counter);
                PrintSpeedInMetersPerSecond(thisMotorcycle);
                Console.WriteLine(" m/s");
                counter++;
            }
            Console.WriteLine("\nPress any key to go back to main menu");
            Console.ReadKey();
        }
        //Calls GetMetersPerSecond to show get M/S calculatios for each vehicle when menu number 4 was picked
        private void PrintSpeedInMetersPerSecond(IVehicle vehicleToPrint)
        {       
            Console.Write(vehicleToPrint.GetMetersPerSecond);
        }

        public void GetData()
        {
            List<string> dataRows = Filehandler.GetSavedData();
            _allVehicles = DataParser.GetVehiclesFromSavedData(dataRows);

            //SEDAN: FYLL LISTORNA _motorcycles, _cars, _boats från _allVehicles
        }

        public void Start()
        {
            bool executeAgain = true;

            while (executeAgain)
            {
                PrintBaseMenu();
                SetMenuChoice();
                if (_baseChoice == VehicleType.unidentified)
                    executeAgain = false;               //Exits program
                else if (_baseChoice == VehicleType.all)
                    PrintMsList();
                else
                {
                    PrintListOfVehicle();
                    if (_numbOfVehicleChoice == -1)     //Means user pressed "+"
                        AddVehicle();
                    else                                //User pressed 0-9
                    {
                        try
                        {
                            ChosenVehicleInfoMenu();
                            if (_newSpeed == -1)            //Means user pressed "-"
                                RemoveVehicle();
                            else
                                ChangeVehicle();
                        }
                        catch (ArgumentOutOfRangeException ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.WriteLine("Press any key to go back to main manu.");
                            Console.ReadKey();
                        }
                    }
                }
            }
        }
        public void SaveData()
        {
            //FYLL _allVehicles FRÅN LISTORNA _motorcycles, _cars, _boats
            List<string> listOfRowsToSave = DataParser.CreateDataToSaveFromList(_allVehicles);
            Filehandler.SaveData(listOfRowsToSave);
        }
    }
}