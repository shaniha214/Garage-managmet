using System;
using System.Collections.Generic;
using EnumTools;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        public List<GarageVehicleInfo> m_VehiclesInTheGarage = new List<GarageVehicleInfo>();

        public GarageVehicleInfo FindVehicleByLicense(string i_LicenseNum)
        {
            GarageVehicleInfo vehicleInfo = null;
            string licenseNumber;

            foreach (GarageVehicleInfo vehicle in m_VehiclesInTheGarage)
            {
                licenseNumber = vehicle.GetLicenseNumber();
                if (licenseNumber == i_LicenseNum)
                {
                    vehicleInfo = vehicle;
                }
            }

            return vehicleInfo;
        }

        public List<GarageVehicleInfo> SortVehiclesInGarage(eSortTypes i_SortType)
        {
            Compareres compare = new Compareres();

            compare.SortType = i_SortType;
            m_VehiclesInTheGarage.Sort(compare);
            return m_VehiclesInTheGarage;
        }

        public bool NewVehicleInGarage(string i_LicenseNum)
        {
            bool newVehicle = false;
            GarageVehicleInfo vehicleInfo;

            vehicleInfo = FindVehicleByLicense(i_LicenseNum);
            if(vehicleInfo != null)
            {
                vehicleInfo.Status = eVehicleStatus.InAmendment;
                newVehicle = true;
            }

            return newVehicle;
        }

        public bool VehicleInGarageChecker(string i_LicenseNum)
        {
            bool isExists = false;
            GarageVehicleInfo vehicleInfo;

            vehicleInfo = FindVehicleByLicense(i_LicenseNum);
            if (vehicleInfo != null)
            {
                isExists = true;
            }

            return isExists;
        }

        public void TankUpVehicleByFuel(string i_LicenseNum, eFuelTypes i_FuelType, float i_Fueladdition)
        {
            VehiclesEnergy energy;
            GarageVehicleInfo vehicleInfo;

            vehicleInfo = FindVehicleByLicense(i_LicenseNum);
            if(vehicleInfo != null)
            {
               energy = vehicleInfo.GetEnrgeyType();
               ((Fuel)energy).FuelTunkUp(i_FuelType, i_Fueladdition);
            }

            return;
        }

        public void VehicleLoadingBtElectric(string i_LicenseNum, float i_Chargingaddition)
        {
            VehiclesEnergy energy;
            GarageVehicleInfo vehicleInfo;

            vehicleInfo = FindVehicleByLicense(i_LicenseNum);
            if(vehicleInfo != null)
            {
                energy = vehicleInfo.GetEnrgeyType();
                i_Chargingaddition = i_Chargingaddition / 60;
                ((EllectricalPower)energy).ChargingBattery(i_Chargingaddition);
            }

            return;
        }

        public List<string> GetVehicleGarageDetails(string i_LicenseNum)
        {
            List<string> details = null;
            GarageVehicleInfo vehicleInfo;

            vehicleInfo = FindVehicleByLicense(i_LicenseNum);
            if(vehicleInfo != null)
            {
                details = new List<string>();
                details = vehicleInfo.GetDetails();
            }

            return details;
        }

        public void ChangeStatus(string i_LicenseNum, eVehicleStatus i_Status)
        {
            GarageVehicleInfo vehicleInfo;

            vehicleInfo = FindVehicleByLicense(i_LicenseNum);
            if (vehicleInfo != null)
            {
                vehicleInfo.Status = i_Status;
            }
        }

        public void BlowingWheelsToTheMaximum(string i_LicenseNum)
        {
            List<Wheels> wheels = null;
            GarageVehicleInfo vehicleInfo;

            vehicleInfo = FindVehicleByLicense(i_LicenseNum);
            wheels = vehicleInfo.GetVehiclesWheels();
            if (wheels != null)
            {
                foreach (Wheels wheel in wheels)
                {
                    wheel.MaxAirPressure();
                }
            }
        }
    }
}
