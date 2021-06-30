using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class VehicleFactoy
    {
        public enum eVehicleTypes
        {
            Car,
            Motorcycle,
            Truck,
        }

        public Vehicle CreatVehicle(string i_ModelName, string i_LicenseNumber, eVehicleTypes i_VehicleTypes, float i_RemainingEnergy, string i_ManufacturerName, float i_CurrentAirPressure, EnumTools.eEnergyTypes i_EnergyType)
        {
            Vehicle newVehicle = null;

            switch (i_VehicleTypes)
            {
                case eVehicleTypes.Car:
                    newVehicle = new Car(i_ModelName, i_LicenseNumber, i_RemainingEnergy, i_ManufacturerName, i_CurrentAirPressure, i_EnergyType);
                    break;
                case eVehicleTypes.Motorcycle:
                    newVehicle = new Motorcycle(i_ModelName, i_LicenseNumber, i_RemainingEnergy, i_ManufacturerName, i_CurrentAirPressure, i_EnergyType);
                    break;
                case eVehicleTypes.Truck:
                    newVehicle = new Truck(i_ModelName, i_LicenseNumber, i_RemainingEnergy, i_ManufacturerName, i_CurrentAirPressure, i_EnergyType);
                    break;
            }

            return newVehicle;
        }
    }
}
