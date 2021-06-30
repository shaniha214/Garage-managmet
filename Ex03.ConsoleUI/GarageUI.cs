using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;
using System.Reflection;

namespace Ex03.ConsoleUI
{
    public class GarageUI
    {
        public static string PrintMenuGarage()
        {
            string selectableOptions;
            Console.WriteLine("Welcome to the garage:");
            Console.WriteLine("please press number from the options and after press enter:");
            Console.WriteLine("1. Enter a new vehicle into the garage.");
            Console.WriteLine("2. Show a list of vehicle sorted by license numbers in the garage.");
            Console.WriteLine("3. Changing the status of a vehicle in the garage.");
            Console.WriteLine("4. Blowing the wheels to the maximum.");
            Console.WriteLine("5. Tunk up a vehicle by fuel.");
            Console.WriteLine("6. Charge a vehicle by ellectric power.");
            Console.WriteLine("7. watch vehicle data");
            Console.WriteLine("8. exit");
            selectableOptions = Console.ReadLine();
            return selectableOptions;
        }

        public static void SetDoorVehicle(Vehicle o_Vehicle)
        {
            EnumTools.eDoorNumbers door;
            Type vehicleType = o_Vehicle.GetType();
            PropertyInfo doorPropertyInfo = vehicleType.GetProperty("DoorNumber");

            if (doorPropertyInfo != null)
            {
                door = GetDoor();
                doorPropertyInfo.SetValue(o_Vehicle, door, null);
            }
        }

        public static void SetColorVehicle(Vehicle o_Vehicle)
        {
            EnumTools.eCarsColors colorVehicle;
            Type vehicleType = o_Vehicle.GetType();
            PropertyInfo colorPropertyInfo = vehicleType.GetProperty("CarColor");

            if (colorPropertyInfo != null)
            {
                colorVehicle = GetColorVehicle();
                colorPropertyInfo.SetValue(o_Vehicle, colorVehicle, null);
            }
        }

        public static void SetEngineCapacity(Vehicle o_Vehicle)
        {
            int capacityOfEngine;
            Type vehicleType = o_Vehicle.GetType();
            PropertyInfo propertyInfo = vehicleType.GetProperty("EngineCapacity");

            if (propertyInfo != null)
            {
                capacityOfEngine = GetCapacityOfEngine();
                propertyInfo.SetValue(o_Vehicle, capacityOfEngine, null);
            }
        }

        public static void SetLicenseType(Vehicle o_Vehicle)
        {
            EnumTools.eLicenseTypes typeOfLicense;
            Type vehicleType = o_Vehicle.GetType();
            PropertyInfo propertyInfo = vehicleType.GetProperty("LicenseType");

            if (propertyInfo != null)
            {
                typeOfLicense = GetTypeOfLicense();
                propertyInfo.SetValue(o_Vehicle, typeOfLicense, null);
            }
        }

        public static void SetMaximumWeight(Vehicle o_Vehicle)
        {
            float capacityOfCargo;
            Type vehicleType = o_Vehicle.GetType();
            PropertyInfo propertyInfo = vehicleType.GetProperty("MaximumWeight");

            if (propertyInfo != null)
            {
                capacityOfCargo = GetMaximumWeight();
                propertyInfo.SetValue(o_Vehicle, capacityOfCargo, null);
            }
        }

        public static void SetDangerousMaterialDelivery(Vehicle o_Vehicle)
        {
            bool drivesHazardousMaterials;
            Type vehicleType = o_Vehicle.GetType();
            PropertyInfo propertyInfo = vehicleType.GetProperty("DangerousMaterialDelivery");

            if (propertyInfo != null)
            {
                drivesHazardousMaterials = GetDrivesHazardousMaterials();
                propertyInfo.SetValue(o_Vehicle, drivesHazardousMaterials, null);
            }
        }

        public static void ErrorMessage()
        {
            Console.WriteLine("Invalid input.");
        }

        public static void vehicleIsAlreadyInGarage()
        {
            Console.WriteLine("The vehicle is already in the garage");
        }

        public static void NotValidEnergy()
        {
            Console.WriteLine("The vehicle is using other type of energy");
        }

        public static void SuccesOperation()
        {
            Console.WriteLine("The action succeeded");
        }

        public static void LicenseNotFound()
        {
            Console.WriteLine("License was not found");
        }

        public static void UnSupportedVehicle()
        {
            Console.WriteLine("this vehicle not supported in this garage");
        }

        public static string MesegeToContinue()
        {
            Console.WriteLine("Please press enter to go back the menu");
            return Console.ReadLine();
        }

        public static void PrintVehicles(List<GarageVehicleInfo> i_Vehicles)
        {
            foreach (GarageVehicleInfo vehicle in i_Vehicles)
            {
                Console.WriteLine(string.Format("License number: {0}  status: {1}", vehicle.GetLicenseNumber(), vehicle.Status));
            }
        }

        public static EnumTools.eSortTypes OptionPrint()
        {
            string getOption = null;
            bool unValid = true;

            while (unValid)
            {
                Console.WriteLine("if you want to print the list according to their stauts in the garage press 1 else 0");
                getOption = Console.ReadLine();
                unValid = getOption != "1" && getOption != "0";
            }

            EnumTools.eSortTypes sort = (EnumTools.eSortTypes)Enum.Parse(typeof(EnumTools.eSortTypes), getOption);

            return sort;
        }

        public static void NotHaveVehicleInGarage()
        {
            Console.WriteLine("The vehicle is not in the garage");
        }

        public static void NoticeStatusChanged()
        {
            Console.WriteLine("This vehicle already in the garge and his status change.");
        }

        public static EnumTools.eVehicleStatus GetStatus()
        {
            string status;
            int numOption = 0;
            const bool v_CheckValidInput = true;
            EnumTools.eVehicleStatus vehicleStatus;
            int length = Enum.GetNames(typeof(EnumTools.eVehicleStatus)).Length;

            Console.WriteLine("Please enter your new vehicle status and press enter.");
            foreach (string enumName in Enum.GetNames(typeof(EnumTools.eVehicleStatus)))
            {
                Console.WriteLine(string.Format("{0} = {1}", enumName, numOption));
                numOption++;
            }

            while (v_CheckValidInput)
            {
                try
                {
                    status = Console.ReadLine();
                    vehicleStatus = (EnumTools.eVehicleStatus)Enum.Parse(typeof(EnumTools.eVehicleStatus), status);
                    if ((int)vehicleStatus <= length - 1 && (int)vehicleStatus >= 0)
                    {
                        Console.WriteLine("status vehicle changed to {0}", vehicleStatus);
                        return vehicleStatus;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input, try again");
                    }
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Invalid input, try again");
                }
            }
        }

        public static float GetAmountFuel()
        {
            string amount;
            const bool v_CheckValidInput = true;

            Console.WriteLine("Please enter the amount of fuel to fill and the press enter.");
            while (v_CheckValidInput)
            {
                try
                {
                    amount = Console.ReadLine();
                    return float.Parse(amount);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid data, try again");
                }
                catch (OutOfRangeErorsException)
                {
                    ErrorMessage();
                }
            }
        }

        public static VehicleFactoy.eVehicleTypes GetVehicleType()
        {
            string type;
            int numberOfOption = 0;
            const bool v_CheckValidInput = true;
            VehicleFactoy.eVehicleTypes vehicleType;
            int length = Enum.GetNames(typeof(VehicleFactoy.eVehicleTypes)).Length;

            Console.WriteLine("Please enter your vehicle type and the press enter.");
            foreach (string name in Enum.GetNames(typeof(VehicleFactoy.eVehicleTypes)))
            {
                Console.WriteLine(string.Format("{0} = {1}", name, numberOfOption));
                numberOfOption++;
            }

            while (v_CheckValidInput)
            {
                try
                {
                    type = Console.ReadLine();
                    vehicleType = (VehicleFactoy.eVehicleTypes)Enum.Parse(typeof(VehicleFactoy.eVehicleTypes), type);
                    if ((int)vehicleType > length - 1 || (int)vehicleType < 0)
                    {
                        Console.WriteLine("Invalid input, try again");
                    }
                    else
                    {
                        return vehicleType;
                    }
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Invalid input, try again");
                }
            }
        }

        public static EnumTools.eEnergyTypes GetVehicleEnergyType()
        {
            string type;
            int numberOfOption = 0;
            const bool v_CheckValidInput = true;
            EnumTools.eEnergyTypes vehicleType;
            int length = Enum.GetNames(typeof(EnumTools.eEnergyTypes)).Length;

            Console.WriteLine("Please enter your vehicle type and the press enter.");
            foreach (string name in Enum.GetNames(typeof(EnumTools.eEnergyTypes)))
            {
                Console.WriteLine(string.Format("{0} = {1}", name, numberOfOption));
                numberOfOption++;
            }

            while (v_CheckValidInput)
            {
                try
                {
                    type = Console.ReadLine();
                    vehicleType = (EnumTools.eEnergyTypes)Enum.Parse(typeof(EnumTools.eEnergyTypes), type);
                    if ((int)vehicleType > length - 1 || (int)vehicleType < 0)
                    {
                        Console.WriteLine("Invalid input, try again");
                    }
                    else
                    {
                        return vehicleType;
                    }
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Invalid input, try again");
                }
            }
        }

        public static string GetOwnerName()
        {
            bool unValidInput = true;
            string ownerName = null;
            int result;

            while (unValidInput)
            {
                Console.WriteLine("Please enter your name and press enter.");
                ownerName = Console.ReadLine();
                unValidInput = int.TryParse(ownerName, out result);
            }

            return ownerName;
        }

        public static string GetPhoneNumber()
        {
            string phoneNumber = null;
            bool unValidInput = true;
            int result;

            while (unValidInput)
            {
                Console.WriteLine("Please enter your phone number and press enter.");
                phoneNumber = Console.ReadLine();
                unValidInput = !int.TryParse(phoneNumber, out result);
            }

            return phoneNumber;
        }

        public static string GetModelName()
        {
            string nameOfModel;

            Console.WriteLine("Please enter vchicle model name and press enter.");
            nameOfModel = Console.ReadLine();

            return nameOfModel;
        }

        public static float GetReamainingEnergy()
        {
            string percentageReamainingEnergy;
            const bool v_CheckValidInput = true;

            Console.WriteLine("Please enter vehicle reamaining Energy and press enter.");
            while (v_CheckValidInput)
            {
                try
                {
                    percentageReamainingEnergy = Console.ReadLine();
                    return float.Parse(percentageReamainingEnergy);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input, try again");
                }
                catch (OutOfRangeErorsException)
                {
                    ErrorMessage();
                }
            }
        }

        public static string GetNameOfManufacturer()
        {
            string nameOfManufacturer;

            Console.WriteLine("Please enter manufacturer name and press enter.");
            nameOfManufacturer = Console.ReadLine();
            return nameOfManufacturer;
        }

        public static float GetCurrAirPressure()
        {
            string currentAirPressure;
            const bool v_CheckValidInput = true;

            Console.WriteLine("Please enter current Air Pressure and press enter.");
            while (v_CheckValidInput)
            {
                try
                {
                    currentAirPressure = Console.ReadLine();
                    return float.Parse(currentAirPressure);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input, try again");
                }
                catch (OutOfRangeErorsException)
                {
                    ErrorMessage();
                }
            }
        }

        public static EnumTools.eCarsColors GetColorVehicle()
        {
            string colorVehicle;
            int numOfOption = 0;
            EnumTools.eCarsColors vehicleColor;
            const bool v_CheckValidInput = true;
            int length = Enum.GetNames(typeof(EnumTools.eCarsColors)).Length;

            Console.WriteLine("Please enter your new vehicle status and press enter.");
            foreach (string nameOfEnum in Enum.GetNames(typeof(EnumTools.eCarsColors)))
            {
                Console.WriteLine(string.Format("{0} = {1}", nameOfEnum, numOfOption));
                numOfOption++;
            }

            while (v_CheckValidInput)
            {
                try
                {
                    colorVehicle = Console.ReadLine();
                    vehicleColor = (EnumTools.eCarsColors)Enum.Parse(typeof(EnumTools.eCarsColors), colorVehicle);
                    if ((int)vehicleColor > length - 1 || (int)vehicleColor < 0)
                    {
                        Console.WriteLine("Invalid input, try again");
                    }
                    else
                    {
                        return vehicleColor;
                    }
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Invalid input, try again");
                }
            }
        }

        public static EnumTools.eDoorNumbers GetDoor()
        {
            string doorsVehicle;
            int numOfOption = 0;
            const bool v_CheckValidInput = true;
            EnumTools.eDoorNumbers doorVehicle;
            int lengthName = Enum.GetNames(typeof(EnumTools.eDoorNumbers)).Length;

            Console.WriteLine("Please enter vehicle door numbers and press enter.");
            foreach (string nameOfEnum in Enum.GetNames(typeof(EnumTools.eDoorNumbers)))
            {
                Console.WriteLine(string.Format("{0} = {1}", nameOfEnum, numOfOption));
                numOfOption++;
            }

            while (v_CheckValidInput)
            {
                try
                {
                    doorsVehicle = Console.ReadLine();
                    doorVehicle = (EnumTools.eDoorNumbers)Enum.Parse(typeof(EnumTools.eDoorNumbers), doorsVehicle);
                    if ((int)doorVehicle > lengthName - 1 || (int)doorVehicle < 0)
                    {
                        Console.WriteLine("Invalid input, try again");
                    }
                    else
                    {
                        return doorVehicle;
                    }
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Invalid input, try again");
                }
            }
        }

        public static bool GetDrivesHazardousMaterials()
        {
            const bool v_CheckValidInput = true;
            string haveHazardousMaterials;

            Console.WriteLine("Please enter true or false if Have Hazardous Materials and the press enter.");
            while (v_CheckValidInput)
            {
                try
                {
                    haveHazardousMaterials = Console.ReadLine();
                    return bool.Parse(haveHazardousMaterials);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid data, try again");
                }
            }
        }

        public static float GetMaximumWeight()
        {
            string capacityOfCargo;
            const bool v_CheckValidInput = true;

            Console.WriteLine("Please enter Maximum weight and press enter.");
            while (v_CheckValidInput)
            {
                try
                {
                    capacityOfCargo = Console.ReadLine();
                    return float.Parse(capacityOfCargo);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input, try again");
                }
            }
        }

        public static EnumTools.eLicenseTypes GetTypeOfLicense()
        {
            string typeOfLicense;
            int numOfOption = 0;
            EnumTools.eLicenseTypes typeLicense;
            const bool v_CheckValidInput = true;
            int length = Enum.GetNames(typeof(EnumTools.eLicenseTypes)).Length;

            Console.WriteLine("Please enter type license and press enter.");
            foreach (string nameOfEnum in Enum.GetNames(typeof(EnumTools.eLicenseTypes)))
            {
                Console.WriteLine(string.Format("{0} = {1}", nameOfEnum, numOfOption));
                numOfOption++;
            }

            while (v_CheckValidInput)
            {
                try
                {
                    typeOfLicense = Console.ReadLine();
                    typeLicense = (EnumTools.eLicenseTypes)Enum.Parse(typeof(EnumTools.eLicenseTypes), typeOfLicense);
                    if ((int)typeLicense > length - 1 || (int)typeLicense < 0)
                    {
                        Console.WriteLine("Invalid input, try again");
                    }
                    else
                    {
                        return typeLicense;
                    }
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Invalid input, try again");
                }
            }
        }

        public static string GetLicenseNumber()
        {
            string licenseNumber = null;
            bool unValid = true;
            int result;

            while(unValid)
            {
               Console.WriteLine("Please enter the license number and press enter");
               licenseNumber = Console.ReadLine();
               unValid = !int.TryParse(licenseNumber, out result);
            }

            return licenseNumber;
        }

        public static int GetCapacityOfEngine()
        {
            string capacityOfEngine;
            const bool v_CheckValidInput = true;

            Console.WriteLine("Please enter engine Capacity and press enter.");
            while (v_CheckValidInput)
            {
                try
                {
                    capacityOfEngine = Console.ReadLine();
                    return int.Parse(capacityOfEngine);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input, try again");
                }
            }
        }

        public static EnumTools.eFuelTypes GetTypeFuel()
        {
            int numOfOption = 0;
            string fuelType;
            EnumTools.eFuelTypes fuelTypeVehicle;
            const bool v_CheckValidInput = true;
            int length = Enum.GetNames(typeof(EnumTools.eFuelTypes)).Length;

            Console.WriteLine("Please enter new vehicle status and press enter.");
            foreach (string enumName in Enum.GetNames(typeof(EnumTools.eFuelTypes)))
            {
                Console.WriteLine(string.Format("{0} = {1}", enumName, numOfOption));
                numOfOption++;
            }

            while (v_CheckValidInput)
            {
                try
                {
                    fuelType = Console.ReadLine();
                    fuelTypeVehicle = (EnumTools.eFuelTypes)Enum.Parse(typeof(EnumTools.eFuelTypes), fuelType);
                    if ((int)fuelTypeVehicle > length - 1 || (int)fuelTypeVehicle < 0)
                    {
                        Console.WriteLine("Invalid input, try again");
                    }
                    else
                    {
                        return fuelTypeVehicle;
                    }
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Invalid input, try again");
                }
            }
        }

        public static float GetcapacityElectric()
        {
            string capacity;
            const bool v_CheckValidInput = true;

            Console.WriteLine("Please enter the capacity to charging and press enter.");
            while (v_CheckValidInput)
            {
                try
                {
                    capacity = Console.ReadLine();
                    return float.Parse(capacity);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input, try again");
                }
                catch (OutOfRangeErorsException)
                {
                    ErrorMessage();
                }
            }
        }

        public static void PrintDetailsOfVehicle(List<string> i_Details)
        {
            Console.WriteLine("vehicle details:");
            foreach (string detail in i_Details)
            {
                Console.WriteLine(detail);
            }
        }
    }
}
