namespace StatePattern.GumballMachine;

public class GumballMachine
{
    public GumballMachine(int count)
    {
        Count = count;

        State = Count > 0
            ? GumballMachineStates.NoQuarter
            : GumballMachineStates.SoldOut;
    }

    public GumballMachineStates State { get; set; }
    public int Count { get; set; }

    public void PrintMachineState()
    {
        Console.WriteLine("Machine Status:  " + State);
        Console.WriteLine("Inventory:  " + Count);
    }

    public void InsertQuarter()
    {
        switch (State)
        {
            case GumballMachineStates.HasQuarter:
                Console.WriteLine("You can't insert another quarter");
                break;

            case GumballMachineStates.NoQuarter:
                Console.WriteLine("You inserted a quarter");
                State = GumballMachineStates.HasQuarter;
                break;

            case GumballMachineStates.SoldOut:
                Console.WriteLine("You can't insert a quarter, the machine is sold out!");
                break;

            case GumballMachineStates.Sold:
                Console.WriteLine("Please wait, we're already dispensing your gumball");
                break;

            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public void EjectQuarter()
    {
        switch (State)
        {
            case GumballMachineStates.HasQuarter:
                Console.WriteLine("Quarter returned");
                State = GumballMachineStates.NoQuarter;
                break;

            case GumballMachineStates.NoQuarter:
                Console.WriteLine("You haven't inserted a quarter");
                break;

            case GumballMachineStates.Sold:
                Console.WriteLine("Sorry, you already turned the crank");
                break;

            case GumballMachineStates.SoldOut:
                Console.WriteLine("You can't eject, you haven't inserted a quarter yet");
                break;

            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public void TurnCrank()
    {
        switch (State)
        {
            case GumballMachineStates.Sold:
                Console.WriteLine("Turning twice doesn't get you another gumball!");
                break;

            case GumballMachineStates.NoQuarter:
                Console.WriteLine("You turned the crank, but you didn't insert a quarter");
                break;

            case GumballMachineStates.SoldOut:
                Console.WriteLine("You turned, but there's no gumballs left to dispense");
                break;

            case GumballMachineStates.HasQuarter:
                Console.WriteLine("You turned...");
                State = GumballMachineStates.Sold;

                Dispense();

                break;

            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public void Dispense()
    {
        switch (State)
        {
            case GumballMachineStates.Sold:
                Console.WriteLine("A gumball comes rolling out of the slot");
                Count -= 1;

                if (Count == 0)
                {
                    Console.WriteLine("Oops, out of gumballs");
                    State = GumballMachineStates.SoldOut;
                }
                else
                {
                    State = GumballMachineStates.NoQuarter;
                }

                break;

            case GumballMachineStates.NoQuarter:
                Console.WriteLine("You need to insert a quarter first");
                break;

            case GumballMachineStates.SoldOut:
                Console.WriteLine("No gumball dispensed");
                break;

            case GumballMachineStates.HasQuarter:
                Console.WriteLine("You need to turn the crank");
                break;

            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}