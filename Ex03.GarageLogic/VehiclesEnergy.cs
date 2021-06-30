using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class VehiclesEnergy
    {
        private readonly float r_MaximumQuantity;
        private float m_CurrentQuantity;

        public VehiclesEnergy(float i_CurrentQuantity, float i_MaximumQuantity)
        {
            OutOfRangeErorsException eror;

            if (i_CurrentQuantity >= 0 && i_CurrentQuantity <= i_MaximumQuantity)
            {
                m_CurrentQuantity = i_CurrentQuantity;
            }
            else
            {
                eror = new OutOfRangeErorsException(0, r_MaximumQuantity);
                throw eror;
            }

            r_MaximumQuantity = i_MaximumQuantity;
        }

        public float CurrentQuantity
        {
            get { return m_CurrentQuantity; }
            set { m_CurrentQuantity = value; }
        }

        public float MaximumQuantity
        {
            get { return r_MaximumQuantity; }
        }

        public abstract List<string> GetDetails(List<string> i_Details);
    }
}
