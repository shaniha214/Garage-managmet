using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private string m_LicenseNum;
        private float m_RemainingEnergy;
        private string m_ModelName;
        public readonly List<Wheels> r_VehiclesWheels;
        public VehiclesEnergy m_EnergyType;

        public Vehicle(string i_ModelName, string i_LicenseNum, float i_RemainingEnergy, string i_ManufacturerName, float i_CurrentAirPressure, float i_MaxAirPressure, int i_NumOfWheels)
        {
            Wheels wheel;

            m_ModelName = i_ModelName;
            m_LicenseNum = i_LicenseNum;
            m_RemainingEnergy = i_RemainingEnergy;
            wheel = new Wheels(i_ManufacturerName, i_CurrentAirPressure, i_MaxAirPressure);
            r_VehiclesWheels = new List<Wheels>();
            for (int i = 0; i < i_NumOfWheels; i++)
            {
                r_VehiclesWheels.Add(wheel);
            }
        }

        public List<Wheels> VehiclesWheels
        {
            get { return r_VehiclesWheels; }
        }

        public VehiclesEnergy EnrgeyType
        {
            get { return m_EnergyType; }
        }

        public string LicenseNum
        {
            get { return m_LicenseNum; }
            set { m_LicenseNum = value; }
        }

        public string ModelName
        {
            get { return m_ModelName; }
            set { m_ModelName = value; }
        }

        public float RemainingEnergy
        {
            get { return m_RemainingEnergy; }
            set { m_RemainingEnergy = value; }
        }

        public List<string> GetVehicleDetails(List<string> i_Details)
        {
            i_Details.Add("Model name:" + m_ModelName);
            i_Details.Add("License number:" + m_LicenseNum);
            i_Details = r_VehiclesWheels[0].GetDetails(i_Details);
            i_Details = GetDetails(i_Details);
            i_Details = m_EnergyType.GetDetails(i_Details);
            return i_Details;
        }

        public abstract List<string> GetDetails(List<string> i_Details);
    }
}
