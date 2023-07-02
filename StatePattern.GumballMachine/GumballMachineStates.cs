using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.GumballMachine
{
    public enum GumballMachineStates
    {
        SoldOut,
        NoQuarter,
        HasQuarter,
        Sold
    }
}
