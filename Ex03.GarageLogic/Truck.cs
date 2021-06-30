using System;
using System.Collections.Generic;
using EnumTools;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private bool m_DangerousMaterialDelivery;
        private float m_MaximumWeight;

        public Truck(string i_ModelName, string i_LicenseNum, float i_RemainingEnergy, string i_ManufacturerName, float i_CurrentAirPressure, eEnergyTypes i_eEnergyTypes)
               : base(i_ModelName, i_LicenseNum, i_RemainingEnergy, i_ManufacturerName, i_CurrentAirPressure, 26, 16)
        {
            switch (i_eEnergyTypes)
            {
                case eEnergyTypes.Fuel:
                    m_EnergyType = new Fuel(eFuelTypes.Soler, i_CurrentAirPressure, 120f);
                    break;
                case eEnergyTypes.Electric:
                    throw new VehicleNotSupported();
                    break;
            }
        }

        public void SetTruckProperties(bool i_DangerousMaterialDelivery, float i_MaximumWeight)
        {
            m_DangerousMaterialDelivery = i_DangerousMaterialDelivery;
            m_MaximumWeight = i_MaximumWeight;
        }

        public override List<string> GetDetails(List<string> o_Details)
        {
            o_Details.Add("Have dangerous materials:" + m_DangerousMaterialDelivery.ToString());
            o_Details.Add("volume maximum weight:" + m_MaximumWeight);
            return o_Details;
        }

        public bool DangerousMaterialDelivery
        {
            get { return m_DangerousMaterialDelivery; }
            set { m_DangerousMaterialDelivery = value; }
        }

        public float MaximumWeight
        {
            get { return m_MaximumWeight; }
            set { m_MaximumWeight = value; }
        }
    }
}
