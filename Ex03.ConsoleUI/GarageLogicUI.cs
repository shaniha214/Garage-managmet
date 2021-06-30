using System;
using System.Collections.Generic;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class GarageLogicUI
    {
        private readonly Garage r_Garage = new Garage();
        private readonly VehicleFactoy r_VehicleFactoy = new VehicleFactoy();

        public void GarageMenu()
        {
            bool toExit = false;
            string selectableOptions;

            while (!toExit)
            {
                selectableOptions = GarageUI.PrintMenuGarage();
                switch (selectableOptions)
                {
                    case "1":
                        Console.Clear();
                        insertNewVehicle();
                        break;
                    case "2":
                        Console.Clear();
                        showVehiclesList();
                        break;
                    case "3":
                        Console.Clear();
                        statusChanger();
                        break;
                    case "4":
                        Console.Clear();
                        blowWheelsToMax();
                        break;
                    case "5":
                        Console.Clear();
                        tunkUpTheVehicleByFuel();
                        break;
                    case "6":
                        Console.Clear();
                        chargeVehiclebyEllectric();
                        break;
                    case "7":
                        Console.Clear();
                        showVehicleDetails();
                        break;
                    case "8":
                        toExit = true;
                        break;
                }

                Console.Clear();
            }

            Console.WriteLine("goodBye! :)");
        }

        private void insertNewVehicle()
        {
            bool checkIfLicenseExists = false;
            string licenseNumber = GarageUI.GetLicenseNumber();

            checkIfLicenseExists = r_Garage.VehicleInGarageChecker(licenseNumber);
            if (checkIfLicenseExists)
            {
                GarageUI.vehicleIsAlreadyInGarage();
            }
            else
            {
                try
                {
                    addNewVehicle(licenseNumber);
                    GarageUI.SuccesOperation();
                }
                catch (Exception ex)
                {
                    if(ex is OutOfRangeErorsException)
                    {
                          GarageUI.ErrorMessage();
                    }

                    if(ex is VehicleNotSupported)
                    {
                        GarageUI.UnSupportedVehicle();
                    }
                }
            }

            GarageUI.MesegeToContinue();
        }

        private void addNewVehicle(string i_LicenseNum)
        {
            Vehicle newVehicle = null;
            VehicleFactoy.eVehicleTypes vehiclesType = GarageUI.GetVehicleType();
            string modelName = GarageUI.GetModelName();
            string manufacturerName = GarageUI.GetNameOfManufacturer();
            float currAirPressure = GarageUI.GetCurrAirPressure();
            EnumTools.eEnergyTypes energyType = GarageUI.GetVehicleEnergyType();
            float reamainingEnergy = GarageUI.GetReamainingEnergy();

            newVehicle = r_VehicleFactoy.CreatVehicle(modelName, i_LicenseNum, vehiclesType, reamainingEnergy, manufacturerName, currAirPressure, energyType);
            GarageUI.SetColorVehicle(newVehicle);
            GarageUI.SetDoorVehicle(newVehicle);
            GarageUI.SetMaximumWeight(newVehicle);
            GarageUI.SetDangerousMaterialDelivery(newVehicle);
            GarageUI.SetLicenseType(newVehicle);
            GarageUI.SetEngineCapacity(newVehicle);
            addNewVehicleToGarage(newVehicle);
        }

        private void addNewVehicleToGarage(Vehicle i_NewVehicle)
        {
            string masterName = GarageUI.GetOwnerName();
            string phoneNumber = GarageUI.GetPhoneNumber();
            GarageVehicleInfo newVehicle = new GarageVehicleInfo(masterName, phoneNumber, i_NewVehicle);

            r_Garage.m_VehiclesInTheGarage.Add(newVehicle);
        }

        private void showVehiclesList()
        {
            EnumTools.eSortTypes option = 0;

            r_Garage.m_VehiclesInTheGarage = r_Garage.SortVehiclesInGarage(option);
            GarageUI.PrintVehicles(r_Garage.m_VehiclesInTheGarage);
            option = GarageUI.OptionPrint();
            if (option != 0)
            {
                r_Garage.m_VehiclesInTheGarage = r_Garage.SortVehiclesInGarage(option);
                GarageUI.PrintVehicles(r_Garage.m_VehiclesInTheGarage);
            }

            GarageUI.MesegeToContinue();
        }

        private void statusChanger()
        {
            bool checkIfLicenseExists;
            string licenseNumber = GarageUI.GetLicenseNumber();
            EnumTools.eVehicleStatus status;

            checkIfLicenseExists = r_Garage.VehicleInGarageChecker(licenseNumber);
            if (checkIfLicenseExists)
            {
                status = GarageUI.GetStatus();
                r_Garage.ChangeStatus(licenseNumber, status);
                GarageUI.SuccesOperation();
            }
            else
            {
                GarageUI.LicenseNotFound();
            }

            GarageUI.MesegeToContinue();
        }

        private void blowWheelsToMax()
        {
            bool checkIfLicenseExists;
            string licenseNumber = GarageUI.GetLicenseNumber();
            checkIfLicenseExists = r_Garage.VehicleInGarageChecker(licenseNumber);

            if (checkIfLicenseExists)
            {
                r_Garage.BlowingWheelsToTheMaximum(licenseNumber);
                GarageUI.SuccesOperation();
            }
            else
            {
                GarageUI.LicenseNotFound();
            }

            GarageUI.MesegeToContinue();
        }

        private void tunkUpTheVehicleByFuel()
        {
            string licenseNumber = GarageUI.GetLicenseNumber();
            float addingFuel;
            GarageVehicleInfo garageVehicleInfo = null;
            bool checkIfLicenseExists;
            EnumTools.eFuelTypes fuel;

            checkIfLicenseExists = r_Garage.VehicleInGarageChecker(licenseNumber);
            if (checkIfLicenseExists)
            {
                garageVehicleInfo = r_Garage.FindVehicleByLicense(licenseNumber);
                if (garageVehicleInfo.GetEnrgeyType() is Fuel)
                {
                    fuel = ((Fuel)garageVehicleInfo.GetEnrgeyType()).FuelType;
                    addingFuel = GarageUI.GetAmountFuel();
                    try
                    {
                        r_Garage.TankUpVehicleByFuel(licenseNumber, fuel, addingFuel);
                        GarageUI.SuccesOperation();
                    }
                    catch (OutOfRangeErorsException)
                    {
                        GarageUI.ErrorMessage();
                    }
                }
                else
                {
                    GarageUI.NotValidEnergy();
                }
            }
            else
            {
                GarageUI.NotHaveVehicleInGarage();
            }

            GarageUI.MesegeToContinue();
        }

        private void chargeVehiclebyEllectric()
        {
            string licenseNumber = GarageUI.GetLicenseNumber();
            bool checkIfLicenseExists;
            GarageVehicleInfo garageVehicleInfo = null;

            checkIfLicenseExists = r_Garage.VehicleInGarageChecker(licenseNumber);
            if (checkIfLicenseExists)
            {
                garageVehicleInfo = r_Garage.FindVehicleByLicense(licenseNumber);
                if (garageVehicleInfo.GetEnrgeyType() is EllectricalPower)
                {
                    float addCharging = GarageUI.GetcapacityElectric();
                    try
                    {
                        r_Garage.VehicleLoadingBtElectric(licenseNumber, addCharging);
                        GarageUI.SuccesOperation();
                    }
                    catch (OutOfRangeErorsException)
                    {
                        GarageUI.ErrorMessage();
                    }
                }
                else
                {
                    GarageUI.NotValidEnergy();
                }
            }
            else
            {
                GarageUI.NotHaveVehicleInGarage();
            }

            GarageUI.MesegeToContinue();
        }

        private void showVehicleDetails()
        {
            string numberOflicense;
            List<string> vehicle = new List<string>();
            numberOflicense = GarageUI.GetLicenseNumber();
            vehicle = r_Garage.GetVehicleGarageDetails(numberOflicense);
            if (vehicle != null)
            {
                GarageUI.PrintDetailsOfVehicle(vehicle);
            }
            else
            {
                GarageUI.NotHaveVehicleInGarage();
            }

            GarageUI.MesegeToContinue();
        }
    }
}
