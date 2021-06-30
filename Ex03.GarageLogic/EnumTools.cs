using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumTools
{
    public enum eLicenseTypes
    {
        A = 0,
        B1 = 1,
        AA = 2,
        BB = 3,
    }

    public enum eSortTypes
    {
       License = 0,
       Status = 1,
    }

    public enum eEnergyTypes
    {
        Fuel,
        Electric,
    }

    public enum eCarsColors
    {
        Red,
        silver,
        white,
        Black,
    }

    public enum eDoorNumbers
    {
        Two = 2,
        Tree = 3,
        Four = 4,
        Five = 5,
    }

    public enum eVehicleStatus
    {
        InAmendment = 0,
        Fixed = 1,
        Paid = 2,
    }

    public enum eFuelTypes
    {
        Soler = 0,
        Octan95 = 1,
        Octan96 = 2,
        Octan98 = 3,
    }
}