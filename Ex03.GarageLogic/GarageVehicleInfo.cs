using System;
using System.Collections.Generic;
using EnumTools;

namespace Ex03.GarageLogic
{
    public class GarageVehicleInfo
    {
        private string m_MasterName;
        private string m_PhoneNumber;
        private eVehicleStatus m_Status;
        private Vehicle m_Vehicle;

        public GarageVehicleInfo(string i_Name, string i_PhoneNumber, Vehicle i_Vehicle)
        {
            m_MasterName = i_Name;
            m_PhoneNumber = i_PhoneNumber;
            m_Status = eVehicleStatus.InAmendment;
            m_Vehicle = i_Vehicle;
        }

        public string PhoneNumber
        {
            get { return m_PhoneNumber; }
            set { m_PhoneNumber = value; }
        }

        public string MasterName
        {
            get { return m_MasterName; }
            set { m_MasterName = value; }
        }

        public eVehicleStatus Status
        {
            get { return m_Status; }
            set { m_Status = value; }
        }

        public string GetLicenseNumber()
        {
            string licenseNumber = m_Vehicle.LicenseNum;
            return licenseNumber;
        }

        public List<Wheels> GetVehiclesWheels()
        {
            return m_Vehicle.VehiclesWheels;
        }

        public float GetRemainingEnergy()
        {
            return m_Vehicle.RemainingEnergy;
        }

        public VehiclesEnergy GetEnrgeyType()
        {
            return m_Vehicle.EnrgeyType;
        }

        public List<string> GetDetails()
        {
            List<string> details = new List<string>();

            details.Add("Name:" + m_MasterName);
            details.Add("Phone number:" + m_PhoneNumber);
            details.Add("Status:" + m_Status.ToString());
            details = m_Vehicle.GetVehicleDetails(details);
            return details;
        }
    }
}
