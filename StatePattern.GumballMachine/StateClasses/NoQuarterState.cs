using StatePattern.GumballMachine.Interface;

namespace StatePattern.GumballMachine.StateClasses;

public class NoQuarterState : IState
{
    public GumballMachine GumballMachine;

    public NoQuarterState(GumballMachine gumballMachine)
    {
        GumballMachine = gumballMachine;
    }

    public void InsertQuarter()
    {
        Console.WriteLine("You inserted a quarter.");
        GumballMachine.SetState(GumballMachine.GetHasQuarterState());
    }

    public void EjectQuarter()
    {
        Console.WriteLine("You haven't inserted a quarter yet.");
    }

    public void TurnCrank()
    {
        Console.WriteLine("You turned, but there's no quarter.");
    }

    public void Dispense()
    {
        Console.WriteLine("You need to pay first.");
    }
}