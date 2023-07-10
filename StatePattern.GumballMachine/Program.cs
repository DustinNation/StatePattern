using StatePattern.GumballMachine;

var gumballMachine = new GumballMachine(5);

gumballMachine.PrintMachineState();

Console.WriteLine();

Console.WriteLine("Happy path:");
gumballMachine.InsertQuarter();
gumballMachine.TurnCrank();

gumballMachine.PrintMachineState();

Console.WriteLine("Attempt to cheat the machine with no quarter:");
gumballMachine.InsertQuarter();
gumballMachine.EjectQuarter();
gumballMachine.TurnCrank();

gumballMachine.PrintMachineState();

Console.WriteLine("Happy path:");
gumballMachine.InsertQuarter();
gumballMachine.TurnCrank();

gumballMachine.PrintMachineState();

Console.WriteLine("Happy path:");
gumballMachine.InsertQuarter();
gumballMachine.TurnCrank();

gumballMachine.PrintMachineState();

Console.WriteLine("Attempt to cheat the machine by getting a free quarter:");
gumballMachine.EjectQuarter();

gumballMachine.PrintMachineState();

Console.WriteLine("Attempt to insert a second quarter:");
gumballMachine.InsertQuarter();
gumballMachine.InsertQuarter();
gumballMachine.TurnCrank();

gumballMachine.PrintMachineState();

Console.WriteLine("Happy path, but the machine should be empty after the purchase:");
gumballMachine.InsertQuarter();
gumballMachine.TurnCrank();

gumballMachine.PrintMachineState();

Console.WriteLine("Attempt to buy a gumball from an empty machine:");
gumballMachine.InsertQuarter();
gumballMachine.TurnCrank();

gumballMachine.PrintMachineState();