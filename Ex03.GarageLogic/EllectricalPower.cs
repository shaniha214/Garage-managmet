using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class EllectricalPower : VehiclesEnergy
    {
        public EllectricalPower(float i_RemainingEnergy, float i_MaxEnergy)
            : base(i_RemainingEnergy, i_MaxEnergy)
        {
        }

        public void ChargingBattery(float i_AddCharging)
        {
            OutOfRangeErorsException eror;
            float newTimeBattery = CurrentQuantity + i_AddCharging;

            if (newTimeBattery <= MaximumQuantity)
            {
                CurrentQuantity = newTimeBattery;
            }
            else
            {
                eror = new OutOfRangeErorsException(0, MaximumQuantity);
                throw eror;
            }
        }

        public override List<string> GetDetails(List<string> i_Details)
        {
            i_Details.Add("Time remaining battery:" + CurrentQuantity);
            i_Details.Add("Maximum battery time:" + MaximumQuantity);
            return i_Details;
        }
    }
}