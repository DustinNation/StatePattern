using StatePattern.GumballMachine;

var gumballMachine = new GumballMachine(5);

PrintMachineState(gumballMachine);

Console.WriteLine();

// Happy path:
gumballMachine.InsertQuarter();
gumballMachine.TurnCrank();

Console.WriteLine();

PrintMachineState(gumballMachine);

Console.WriteLine();

// Attempt to cheat the machine with no quarter:
gumballMachine.InsertQuarter();
gumballMachine.EjectQuarter();
gumballMachine.TurnCrank();

Console.WriteLine();

// Happy path:
gumballMachine.InsertQuarter();
gumballMachine.TurnCrank();

Console.WriteLine();

// Happy path:
gumballMachine.InsertQuarter();
gumballMachine.TurnCrank();

Console.WriteLine();

// Attempt to cheat the machine by getting a free quarter:
gumballMachine.EjectQuarter();

Console.WriteLine();

PrintMachineState(gumballMachine);

Console.WriteLine();

// Attempt to insert a second quarter:
gumballMachine.InsertQuarter();
gumballMachine.InsertQuarter();
gumballMachine.TurnCrank();

Console.WriteLine();

// Happy path, but the machine should be empty now:
gumballMachine.InsertQuarter();
gumballMachine.TurnCrank();

Console.WriteLine();

// Attempt to buy a gumball from an empty machine:
gumballMachine.InsertQuarter();
gumballMachine.TurnCrank();

Console.WriteLine();

PrintMachineState(gumballMachine);

void PrintMachineState(GumballMachine gumballMachine)
{
    Console.WriteLine("Machine Status:  " + gumballMachine.State);
    Console.WriteLine("Inventory:  " + gumballMachine.Count);
}
