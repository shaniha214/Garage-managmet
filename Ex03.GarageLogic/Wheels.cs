using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Wheels
    {
        private readonly float r_MaxAirPressure;
        public string m_ManufacturerName;
        public float m_CurrentAirPressure;

        public Wheels(string i_ManufacturerName, float i_CurrAirPressure, float i_MaxAirPressure)
        {
            m_ManufacturerName = i_ManufacturerName;
            m_CurrentAirPressure = i_CurrAirPressure;
            r_MaxAirPressure = i_MaxAirPressure;
        }

        public void InflatWheel(float i_AirPressureaddition)
        {
            float minAirPressure = 0;
            float newAirPressure = m_CurrentAirPressure + i_AirPressureaddition;

            if (newAirPressure <= r_MaxAirPressure)
            {
                m_CurrentAirPressure = newAirPressure;
            }
            else
            {
                OutOfRangeErorsException value = new OutOfRangeErorsException(minAirPressure, r_MaxAirPressure);
                throw value;
            }
        }

        public void MaxAirPressure()
        {
            m_CurrentAirPressure = r_MaxAirPressure;
        }

        public List<string> GetDetails(List<string> i_Details)
        {
            i_Details.Add("Manufacturer name:" + m_ManufacturerName);
            i_Details.Add("Current air pressure:" + m_CurrentAirPressure);
            i_Details.Add("Max air pressure:" + r_MaxAirPressure);

            return i_Details;
        }
    }
}
