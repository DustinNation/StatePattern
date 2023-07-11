using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatePattern.GumballMachine.Interface;

namespace StatePattern.GumballMachine.StateClasses
{
    public class SoldOutState: IState
    {
        public GumballMachine GumballMachine;

        public SoldOutState(GumballMachine gumballMachine)
        {
            GumballMachine = gumballMachine;
        }

        public void InsertQuarter()
        {
            Console.WriteLine("You can't insert a quarter, the machine is sold out!");
        }

        public void EjectQuarter()
        {
            Console.WriteLine("You can't eject, you haven't inserted a quarter yet");
        }

        public void TurnCrank()
        {
            Console.WriteLine("You turned, but there's no gumballs left to dispense");
        }

        public void Dispense()
        {
            Console.WriteLine("No gumball dispensed");
        }

        /// <summary>
        /// Refill the gumball machine.
        /// </summary>
        public void Refill()
        {
            GumballMachine.SetState(GumballMachine.GetNoQuarterState());
        }
    }
}
