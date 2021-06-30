using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class OutOfRangeErorsException : Exception
    {
        public float m_MaxValue;
        public float m_MinValue;

        public OutOfRangeErorsException(float i_MaxValue, float i_MinValue)
        {
            m_MaxValue = i_MaxValue;
            m_MinValue = i_MinValue;
        }
    }
}