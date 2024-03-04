using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.ConsoleUI
{
    class UserInteractions
    {
        public static MenuOptions ShowMenu()
        {
            string chosenOptionStr;
            MenuOptions chosenOption;

            printMainMenu();
            askUserToChooseMenuOption();
            chosenOptionStr = Console.ReadLine();
            chosenOption = MenuOptions.Parse(chosenOptionStr);

            return chosenOption;
        }

        public static void ShowVehicleInformation(StringBuilder i_VehicleInformation)
        {
            Console.WriteLine(i_VehicleInformation);
        }

        public static string AskUserForInformation(KeyValuePair<string, Type> i_InformationPiece)
        {
            string userInput;
            string msg = string.Format("{0} | Type: {1}", i_InformationPiece.Key, i_InformationPiece.Value.Name);

            Console.WriteLine(msg);
            userInput = Console.ReadLine();

            return userInput;
        }

        public static string AskUserForColor()
        {
            Console.WriteLine("Enter a color:");
            printColorMenu();

            string color = Console.ReadLine();

            return color;
        }

        public static string AskUserForNumberOfDoors()
        {
            Console.WriteLine("Enter number of doors:");
            printNumberOfDoorsMenu();

            string numberOfDoors = Console.ReadLine();

            return numberOfDoors;
        }

        public static string AskUserForVehicleState()
        {
            Console.WriteLine("Enter vehicle state:");
            printStateMenu();

            string vehicleState = Console.ReadLine();

            return vehicleState;
        }

        public static string AskUserForVehicleFilterState()
        {
            Console.WriteLine("Enter vehicle state to filter by:");
            printStateFilterMenu();

            string vehicleState = Console.ReadLine();

            return vehicleState;
        }

        public static string AskUserForVehicleType()
        {
            Console.WriteLine("Enter Vehicle type:");
            printTypeMenu();

            string vehicleType = Console.ReadLine();

            return vehicleType;
        }

        public static string AskUserForFuelType()
        {
            Console.WriteLine("Enter Fuel type:");
            printFuelMenu();

            string fuelType = Console.ReadLine();

            return fuelType;
        }

        public static float AskUserForAmountOfFuelLitresToFill()
        {
            Console.WriteLine("Enter amount of fuel litres to fill:");

            float amountToFill = float.Parse(Console.ReadLine());

            return amountToFill;
        }

        public static float AskUserForAmountOfMinutesToChargeBattery()
        {
            Console.WriteLine("Enter amount of minutes to charge the battery:");

            float amountToCharge = float.Parse(Console.ReadLine());

            return amountToCharge;
        }

        public static void PrintListOfLicenseNumbers(List<string> i_LicenseNumbers)
        {
            StringBuilder formatter = new StringBuilder();

            Console.WriteLine("The license numbers are:");

            foreach (string licenseNumber in i_LicenseNumbers)
            {
                formatter.Append(licenseNumber);
                formatter.AppendLine();
            }

            Console.Write(formatter);
        }

        public static void PrintFormatExceptionError(FormatException i_FormatExceptionError)
        {
            Console.WriteLine(string.Format("Invalid format input"));
        }

        public static void PrintArgumentExceptionError(ArgumentException i_ArgumentExceptionError)
        {
            Console.WriteLine(string.Format("Your choice is not valid"));
        }

        public static void PrintValueOutOfRangeExceptionError(string i_ValueOutOfRangeExceptionStr)
        {
            Console.WriteLine(i_ValueOutOfRangeExceptionStr);
        }

        public static void VehicleNotFoundMessage(string i_LicenseNumber)
        {
            Console.WriteLine(string.Format("Vehicle with license number: {0} was not found in the garage", i_LicenseNumber));
        }

        public static void AnnounceSuccessfulInsertion(string i_LicenseNumber)
        {
            string announcement = string.Format("Vehicle with license number {0} was inserted successfully to the garage.", i_LicenseNumber);

            Console.WriteLine(announcement);
        }

        public static void AnnounceSuccessfulFuel(string i_LicenseNumber)
        {
            string announcement = string.Format("Vehicle with license number {0} was fueled successfully", i_LicenseNumber);

            Console.WriteLine(announcement);
        }

        public static void AnnounceSuccessfulCharge(string i_LicenseNumber)
        {
            string announcement = string.Format("Vehicle with license number {0} was charged successfully", i_LicenseNumber);

            Console.WriteLine(announcement);
        }

        public static void AnnounceStateChange(string i_LicenseNumber, string i_VehicleState)
        {
            string announcement = string.Format("Changed the state of vehicle with the license number of {0} to {1} successfully.",
                i_LicenseNumber,
                i_VehicleState);

            Console.WriteLine(announcement);
        }

        public static void AnnounceFailedStateChange(string i_LicenseNumber)
        {
            string announcement = string.Format("Could not change the state of vehicle with the license number of {0}.",
                i_LicenseNumber);

            Console.WriteLine(announcement);
        }

        public static void ShowVehicleInGarageMessage(string i_LicenseNumber)
        {
            Console.WriteLine("Vehicle with license number {0} is already in the garage", i_LicenseNumber);
        }

        public static void ClearScreen()
        {
            Console.Clear();
        }

        public static void PressEnterToMainMenu()
        {
            Console.WriteLine("Press enter to choose a new action");
            Console.ReadLine();
        }

        public static string AskUserForLicenseNumber()
        {
            Console.WriteLine("Enter license number:");

            string licenseNumber = Console.ReadLine();

            return licenseNumber;
        }

        public static string AskUserForLicenseType()
        {
            string licenseType;

            Console.WriteLine("Enter license type:");
            printLicenseTypeMenu();
            licenseType = Console.ReadLine();

            return licenseType;
        }

        private static void printLicenseTypeMenu()
        {
            List<string> licenseTypeItems = new List<string>();

            licenseTypeItems.Add("A1");
            licenseTypeItems.Add("A2");
            licenseTypeItems.Add("AB");
            licenseTypeItems.Add("B2");

            MenuBuilder licenseTypesMenu = new MenuBuilder(licenseTypeItems, 1);

            Console.WriteLine(licenseTypesMenu);
        }

        private static void printNumberOfDoorsMenu()
        {
            List<string> numberOfDoorsItems = new List<string>();

            numberOfDoorsItems.Add("Two doors");
            numberOfDoorsItems.Add("Three doors");
            numberOfDoorsItems.Add("Four doors");
            numberOfDoorsItems.Add("Five doors");

            MenuBuilder numberOfDoorsMenu = new MenuBuilder(numberOfDoorsItems, 2);

            Console.WriteLine(numberOfDoorsMenu);
        }

        private static void printColorMenu()
        {
            List<string> colorMenuItems = new List<string>();

            colorMenuItems.Add("Blue");
            colorMenuItems.Add("White");
            colorMenuItems.Add("Red");
            colorMenuItems.Add("Yellow");

            MenuBuilder colorsMenu = new MenuBuilder(colorMenuItems, 1);

            Console.WriteLine(colorsMenu);
        }

        private static void printFuelMenu()
        {
            List<string> fuelTypeItems = new List<string>();

            fuelTypeItems.Add("Soler");
            fuelTypeItems.Add("Octan95");
            fuelTypeItems.Add("Octan96");
            fuelTypeItems.Add("Octan98");

            MenuBuilder fuelTypesMenu = new MenuBuilder(fuelTypeItems, 1);

            Console.WriteLine(fuelTypesMenu);
        }

        private static void printTypeMenu()
        {
            List<string> vehicleTypeMenuItems = new List<string>();

            vehicleTypeMenuItems.Add("FueledMotorcycle");
            vehicleTypeMenuItems.Add("ElectricMotorcycle");
            vehicleTypeMenuItems.Add("FueledCar");
            vehicleTypeMenuItems.Add("ElectricCar");
            vehicleTypeMenuItems.Add("Truck");

            MenuBuilder vehicleTypesMenu = new MenuBuilder(vehicleTypeMenuItems, 1);
            
            Console.WriteLine(vehicleTypesMenu);
        }

        private static void printStateMenu()
        {
            List<string> stateMenuItems = new List<string>();

            stateMenuItems.Add("UnderRepaired");
            stateMenuItems.Add("Repaired");
            stateMenuItems.Add("Paid");

            MenuBuilder statesMenu = new MenuBuilder(stateMenuItems, 1);

            Console.WriteLine(statesMenu);
        }

        private static void printStateFilterMenu()
        {
            List<string> stateFilterMenuItems = new List<string>();

            stateFilterMenuItems.Add("UnderRepaired");
            stateFilterMenuItems.Add("Repaired");
            stateFilterMenuItems.Add("Paid");
            stateFilterMenuItems.Add("All");

            MenuBuilder statesFilterMenu = new MenuBuilder(stateFilterMenuItems, 1);

            Console.WriteLine(statesFilterMenu);
        }

        private static void askUserToChooseMenuOption()
        {
            string msg = String.Format("Please choose a valid option from the menu");

            Console.WriteLine(msg);
        }

        private static void printMainMenu()
        {
            List<string> menuItems = new List<string>();

            menuItems.Add("Insert a new vehicle to the garage (repair vehicle)");
            menuItems.Add("List all license numbers of the vehicles in the garage");
            menuItems.Add("Change the state of a particular vehicle in the garage");
            menuItems.Add("Fully inflate the wheels of a vehicle");
            menuItems.Add("Refuel a fueled vehicle");
            menuItems.Add("Charge the battery of an electric vehicle");
            menuItems.Add("Show all information relevant to a vehicle");
            menuItems.Add("Exit");

            MenuBuilder mainMenu = new MenuBuilder(menuItems, 1);

            Console.WriteLine(mainMenu);
        }
    }
}
