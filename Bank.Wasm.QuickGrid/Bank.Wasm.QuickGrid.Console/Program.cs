//using Bank.Wasm.QuickGrid.Console;
using Bank.Wasm.QuickGrid.Shared;

var account = new BankAccount("<name>", DateOnly.FromDateTime(DateTime.Now).AddDays(-60), 1000);
Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance} balance.");

account.Withdraw(500, DateOnly.FromDateTime(DateTime.Now), "Rent payment");
//Console.WriteLine(account.Balance);
account.Deposit(100, DateOnly.FromDateTime(DateTime.Now), "friend paid me back");
//Console.WriteLine(account.Balance);

Console.WriteLine(account.Print());

// Test that the initial balances must be positive:
try
{
    var invalidAccount = new BankAccount("invalid", DateOnly.FromDateTime(DateTime.Now), - 55);
}
catch (ArgumentOutOfRangeException e)
{
    Console.WriteLine("Exception caught creating account with negative balance");
    //Console.WriteLine(e.ToString());
}

// Test for a negative balance
try
{
    account.Withdraw(750, DateOnly.FromDateTime(DateTime.Now), "Attempt to overdraw");
}
catch (InvalidOperationException e)
{
    Console.WriteLine("Exception caught trying to overdraw");
    //Console.WriteLine(e.ToString());
}