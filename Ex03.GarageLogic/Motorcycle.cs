using System;
using System.Collections.Generic;
using EnumTools;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        private eLicenseTypes m_LicenseType;
        private int m_EngineCapacity;

        public Motorcycle(string i_ModelName, string i_LicenseNum, float i_RemainingEnergy, string i_ManufacturerName, float i_CurrentAirPressure, eEnergyTypes i_EnrgeyType)
            : base(i_ModelName, i_LicenseNum, i_RemainingEnergy, i_ManufacturerName, i_CurrentAirPressure, 30, 2)
        {
            switch (i_EnrgeyType)
            {
                case eEnergyTypes.Electric:
                    m_EnergyType = new EllectricalPower(i_RemainingEnergy, 1.8f);
                    break;
                case eEnergyTypes.Fuel:
                    m_EnergyType = new Fuel(eFuelTypes.Octan98, i_RemainingEnergy, 6f);
                    break;
            }
        }

        public void SetMotorcycleProperties(eLicenseTypes i_LicenseType, int i_EngineCapacity)
        {
            m_LicenseType = i_LicenseType;
            m_EngineCapacity = i_EngineCapacity;
        }

        public override List<string> GetDetails(List<string> o_Details)
        {
            o_Details.Add("License type:" + m_LicenseType.ToString());
            o_Details.Add("Engine capacity:" + m_EngineCapacity);
            return o_Details;
        }

        public eLicenseTypes LicenseType
        {
            get { return m_LicenseType; }
            set { m_LicenseType = value; }
        }

        public int EngineCapacity
        {
            get { return m_EngineCapacity; }
            set { m_EngineCapacity = value; }
        }
    }
}
