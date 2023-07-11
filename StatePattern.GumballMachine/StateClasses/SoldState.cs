using StatePattern.GumballMachine.Interface;

namespace StatePattern.GumballMachine.StateClasses;

public class SoldState : IState
{
    public GumballMachine GumballMachine;

    public SoldState(GumballMachine gumballMachine)
    {
        GumballMachine = gumballMachine;
    }

    /// <summary>
    /// An inappropriate action for this state
    /// </summary>
    public void InsertQuarter()
    {
        Console.WriteLine("Please wait, we're already dispensing your gumball");
    }

    /// <summary>
    /// An inappropriate action for this state
    /// </summary>
    public void EjectQuarter()
    {
        Console.WriteLine("Sorry, you already turned the crank");
    }

    /// <summary>
    /// An inappropriate action for this state
    /// </summary>
    public void TurnCrank()
    {
        Console.WriteLine("Turning twice doesn't get you another gumball!");
    }

    /// <summary>
    /// <para>We're in the <see cref="SoldState"/>, which means the customer paid.</para>
    /// <para>So, we first need to ask the machine to release a gumball.
    /// Then, we ask the machine what the gumball count is and either transition to
    /// <see cref="NoQuarterState"/> or <see cref="SoldOutState"/></para>
    /// </summary>
    public void Dispense()
    {
        Console.WriteLine("A gumball comes rolling out of the slot");
        GumballMachine.Count -= 1;

        if (GumballMachine.Count == 0)
        {
            Console.WriteLine("Oops, out of gumballs");
            GumballMachine.SetState(GumballMachine.GetSoldOutState());
        }
        else
        {
            GumballMachine.SetState(GumballMachine.GetNoQuarterState());
        }
    }

    /// <summary>
    /// An inappropriate action for this state
    /// </summary>
    public void Refill()
    {
        // do nothing
    }
}