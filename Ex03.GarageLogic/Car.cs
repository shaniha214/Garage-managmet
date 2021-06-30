using System;
using System.Collections.Generic;
using EnumTools;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private eCarsColors m_CarColor;
        private eDoorNumbers m_DoorAmount;

        public Car(string i_ModelName, string i_LicenseNum, float i_RemainingEnergy, string i_ManufacturerName, float i_CurrentAirPressure, eEnergyTypes i_EnrgeyType)
            : base(i_ModelName, i_LicenseNum, i_RemainingEnergy, i_ManufacturerName, i_CurrentAirPressure, 32, 4)
        {
            switch(i_EnrgeyType)
            {
                case eEnergyTypes.Electric:
                    m_EnergyType = new EllectricalPower(i_RemainingEnergy, 3.2f);
                    break;
                case eEnergyTypes.Fuel:
                    m_EnergyType = new Fuel(eFuelTypes.Octan95, i_RemainingEnergy, 45f);
                    break;
            }
        }

        public void SetCarProperties(eDoorNumbers i_DoorNumbers, eCarsColors i_CarColor)
        {
            m_CarColor = i_CarColor;
            m_DoorAmount = i_DoorNumbers;
        }

        public eCarsColors CarColor
        {
            get { return m_CarColor; }
            set { m_CarColor = value; }
        }

        public eDoorNumbers DoorNumber
        {
            get { return m_DoorAmount; }
            set { m_DoorAmount = value; }
        }

        public override List<string> GetDetails(List<string> i_Details)
        {
            i_Details.Add("The car color:" + m_CarColor.ToString());
            i_Details.Add("Doors number:" + m_DoorAmount.ToString());
            return i_Details;
        }
    }
}
