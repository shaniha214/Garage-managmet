using System;
using System.Collections.Generic;
using EnumTools;

namespace Ex03.GarageLogic
{
    public class Fuel : VehiclesEnergy
    {
        private readonly eFuelTypes m_FuelType;

        public Fuel(eFuelTypes i_FuelType, float i_CurrentFuelQuantity, float i_MaximumFuelQuantity)
            : base(i_CurrentFuelQuantity, i_MaximumFuelQuantity)
        {
            m_FuelType = i_FuelType;
        }

        public void FuelTunkUp(eFuelTypes i_FuelType, float i_AddFuel)
        {
            float newFuelQuantity = CurrentQuantity + i_AddFuel;

            if (m_FuelType == i_FuelType && newFuelQuantity <= MaximumQuantity)
            {
                CurrentQuantity = newFuelQuantity;
            }
            else
            {
                OutOfRangeErorsException value = new OutOfRangeErorsException(0, MaximumQuantity);
                throw value;
            }
        }

        public eFuelTypes FuelType
        {
            get { return m_FuelType; }
        }

        public override List<string> GetDetails(List<string> io_FuelDetails)
        {
            io_FuelDetails.Add("Fuel type:" + m_FuelType.ToString());
            io_FuelDetails.Add("Current Fuel quantity:" + CurrentQuantity);
            io_FuelDetails.Add("Maximum Fuel quantity:" + MaximumQuantity);
            return io_FuelDetails;
        }
    }
}
