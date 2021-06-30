using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class BuildVehicle
    {
        public enum TypesOfVehicles
        {
            MotorcycleFuel,
            MotorcycleElectric,
            CarFuel,
            CarElectric,
            Truck
        }

        public Vehicle CreatNewVehicle(string i_ModelName, string i_LicenseNumber, TypesOfVehicles i_VehicleTypes, float i_RemainingEnergy, string i_ManufacturerName, float i_CurrentAirPressure)
        {
            Vehicle newVehicle = null;
            switch (i_VehicleTypes)
            {
                case TypesOfVehicles.CarElectric:
                    EllectricalPower electricCar = new EllectricalPower();
                    newVehicle = new Car(i_ModelName, i_LicenseNumber, electricCar, i_RemainingEnergy, i_ManufacturerName, i_CurrentAirPressure, 0, 0);
                    break;
                case VehicleTypes.CarFuel:
                    FuelVehicles fuelCar = new FuelVehicles();
                    newVehicle = new Car(i_ModelName, i_LicenseNumber, fuelCar, i_RemainingEnergy, i_ManufacturerName, i_CurrentAirPressure, 0, 0);
                    break;
                case VehicleTypes.MotorcycleElectric:
                    ElectricVehicles electricMotorcycle = new ElectricVehicles();
                    newVehicle = new Motorcycle(i_ModelName, i_LicenseNumber, electricMotorcycle, i_RemainingEnergy, 0, 0, i_ManufacturerName, i_CurrentAirPressure);
                    break;
                case VehicleTypes.MotorcycleFuel:
                    FuelVehicles fuelMotorcycle = new FuelVehicles();
                    newVehicle = new Motorcycle(i_ModelName, i_LicenseNumber, fuelMotorcycle, i_RemainingEnergy, 0, 0, i_ManufacturerName, i_CurrentAirPressure);
                    break;
                case VehicleTypes.Truck:
                    FuelVehicles fuelTruk = new FuelVehicles();
                    newVehicle = new Truck(i_ModelName, i_LicenseNumber, fuelTruk, i_RemainingEnergy, i_ManufacturerName, i_CurrentAirPressure, false, 0);
                    break;

            }
            return newVehicle;
        }
    }
}
