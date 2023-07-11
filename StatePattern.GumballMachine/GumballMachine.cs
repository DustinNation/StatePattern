using StatePattern.GumballMachine.Interface;
using StatePattern.GumballMachine.StateClasses;

namespace StatePattern.GumballMachine;

public class GumballMachine
{
    public int Count; // the count instance variable
    public IState State; // the state instance variable


    // All of the states
    public IState DoubleDispenseWinnerState;
    public IState HasQuarterState;
    public IState NoQuarterState;
    public IState SoldOutState;
    public IState SoldState;


    // The constructor takes the initial number of gumballs
    // and stores it in the instance variable
    //
    // It also creates the state instances, one for each.
    public GumballMachine(int count)
    {
        SoldOutState = new SoldOutState(this);
        NoQuarterState = new NoQuarterState(this);
        HasQuarterState = new HasQuarterState(this);
        SoldState = new SoldState(this);
        DoubleDispenseWinnerState = new DoubleDispenseWinnerState(this);

        Count = count;

        // if we have gumballs, we set the state to the NoQuarterState,
        // otherwise, we start in the SoldOutState.
        State = Count > 0
            ? NoQuarterState
            : SoldOutState;
    }

    public void PrintMachineState()
    {
        Console.WriteLine();
        Console.WriteLine("Machine Status:  " + State);
        Console.WriteLine("Inventory:  " + Count);
        Console.WriteLine();
    }


    // Now for the actions:
    // These are now VERY EASY to implement
    // We just delegate to the current state.
    public void InsertQuarter()
    {
        State.InsertQuarter();
    }

    public void EjectQuarter()
    {
        State.EjectQuarter();
    }

    public void TurnCrank()
    {
        State.TurnCrank();
            // We don't need an action method for Dispense() in GumballMachine,
            // because it's just an internal action; a user can't ask the machine to
            // to dispense directly.
            // We do call Dispense() on the IState object from the TurnCrank() method.
        State.Dispense();
    }

    /// <summary>
    /// This is the method that allows other objects
    /// (like our IState objects)
    /// to transition the machine to a different state.
    /// </summary>
    /// <param name="state"></param>
    public void SetState(IState state)
    {
        State = state;
    }

    /// <summary>
    /// This is a helper method that releases the ball and decrements the count instance variable.
    /// </summary>
    public void ReleaseBall()
    {
        Console.WriteLine("A gumball comes rolling out the slot...");
        if (Count > 0)
        {
            Count -= 1;
        }
    }

    public void Refill(int count)
    {
        Count += count;
        Console.WriteLine($"The gumball machine was just refilled; its new count is:  {count}");
        State.Refill();
    }

    #region State Modifiers

    public IState GetHasQuarterState()
    {
        return HasQuarterState;
    }

    public IState GetNoQuarterState()
    {
        return NoQuarterState;
    }

    public IState GetSoldState()
    {
        return SoldState;
    }

    public IState GetSoldOutState()
    {
        return SoldOutState;
    }

    #endregion State Modifiers
}