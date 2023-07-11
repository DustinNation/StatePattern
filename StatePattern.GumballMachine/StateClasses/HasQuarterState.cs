using StatePattern.GumballMachine.Interface;

namespace StatePattern.GumballMachine.StateClasses;

public class HasQuarterState : IState
{
    public GumballMachine GumballMachine;
    public Random RandomWinner = new Random();

    public HasQuarterState(GumballMachine gumballMachine)
    {
        GumballMachine = gumballMachine;
    }

    /// <summary>
    /// An inappropriate action for this state
    /// </summary>
    public void InsertQuarter()
    {
        Console.WriteLine("You can't insert another quarter");
    }

    /// <summary>
    /// Return the customer's quarter and set <see cref="IState"/> to <see cref="NoQuarterState"/>
    /// </summary>
    public void EjectQuarter()
    {
        Console.WriteLine("Quarter returned");
        GumballMachine.SetState(GumballMachine.GetNoQuarterState());
    }

    /// <summary>
    /// When the crank is turned, we transition to <see cref="SoldState"/>
    /// </summary>
    public void TurnCrank()
    {
        Console.WriteLine("You turned...");

        var winner = RandomWinner.Next(1,10);

        if (winner == 1 && GumballMachine.Count > 1)
        {
            GumballMachine.SetState(GumballMachine.DoubleDispenseWinnerState);
        }
        else
        {
            GumballMachine.SetState(GumballMachine.GetSoldState());
        }
    }

    /// <summary>
    /// An inappropriate action for this state
    /// </summary>
    public void Dispense()
    {
        Console.WriteLine("No gumball dispensed.");
    }

    /// <summary>
    /// An inappropriate action for this state
    /// </summary>
    public void Refill()
    {
        // do nothing
    }
}