using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatePattern.GumballMachine.Interface;

namespace StatePattern.GumballMachine.StateClasses
{
    public class DoubleDispenseWinnerState: IState
    {
        public GumballMachine GumballMachine;

        public DoubleDispenseWinnerState(GumballMachine gumballMachine)
        {
            GumballMachine = gumballMachine;
        }

        public void InsertQuarter()
        {
            Console.WriteLine("Please wait, we're already dispensing your gumball");
        }

        public void EjectQuarter()
        {
            Console.WriteLine("Sorry, you already turned the crank");
        }

        public void TurnCrank()
        {
            Console.WriteLine("Turning twice doesn't get you another gumball!");
        }

        public void Dispense()
        {
            GumballMachine.ReleaseBall();
            
            if (GumballMachine.Count == 0)
            {
                GumballMachine.SetState(GumballMachine.SoldOutState);
            }
            else
            {
                GumballMachine.ReleaseBall();
                Console.WriteLine("YOU'RE A WINNER! You got two gumballs for your quarter.");

                if (GumballMachine.Count == 0)
                {
                    Console.WriteLine("Oops, out of gumballs!");
                    GumballMachine.SetState(GumballMachine.GetSoldOutState());
                }
                else
                {
                    GumballMachine.SetState(GumballMachine.GetNoQuarterState());
                }
            }
        }
    }
}
