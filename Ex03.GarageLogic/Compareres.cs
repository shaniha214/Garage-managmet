using System;
using System.Collections.Generic;
using EnumTools;

namespace Ex03.GarageLogic
{
    public class Compareres : IComparer<GarageVehicleInfo>
    {
        private eSortTypes m_SortType;

        public int Compare(GarageVehicleInfo i_Vehicles1, GarageVehicleInfo i_Vehicles2)
        {
            int result = 0;

            switch (m_SortType)
            {
                case eSortTypes.License:
                    result = i_Vehicles1.GetLicenseNumber().CompareTo(i_Vehicles2.GetLicenseNumber());
                    break;
                case eSortTypes.Status:
                    result = i_Vehicles1.Status.CompareTo(i_Vehicles2.Status);
                    break;
            }

            return result;
        }

        public eSortTypes SortType
        {
            get { return m_SortType; }
            set { m_SortType = value; }
        }
    }
}
