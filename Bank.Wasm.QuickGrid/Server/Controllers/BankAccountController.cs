using Bank.Wasm.QuickGrid.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Bank.Wasm.QuickGrid.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BankAccountController : ControllerBase
    {
        private List<Transaction> transactions = new List<Transaction>();

        // GET: <BankAccountController>
        [HttpGet]
        public List<Transaction> Get()
        {
            var account = new BankAccount("<name>", DateOnly.FromDateTime(DateTime.Now).AddDays(-45), 2000);
            account.Withdraw(780.32m, DateOnly.FromDateTime(DateTime.Now).AddDays(-44), "Wheels Dealership");
            account.Withdraw(100m, DateOnly.FromDateTime(DateTime.Now).AddDays(-43), "Village Pantry");
            account.Withdraw(25m, DateOnly.FromDateTime(DateTime.Now).AddDays(-42), "Pizza");
            account.Withdraw(20m, DateOnly.FromDateTime(DateTime.Now).AddDays(-41), "Deli");
            account.Withdraw(80m, DateOnly.FromDateTime(DateTime.Now).AddDays(-40), "Bank of The World");
            account.Withdraw(20m, DateOnly.FromDateTime(DateTime.Now).AddDays(-35), "BART");
            account.Withdraw(11.05m, DateOnly.FromDateTime(DateTime.Now).AddDays(-30), "The Cheese Board");
            account.Withdraw(43.6m, DateOnly.FromDateTime(DateTime.Now).AddDays(-25), "Monterey Market");
            account.Deposit(1711.68m, DateOnly.FromDateTime(DateTime.Now).AddDays(-20), "Bank of The World");
            account.Withdraw(12.17m, DateOnly.FromDateTime(DateTime.Now).AddDays(-15), "Local 123");
            account.Withdraw(27m, DateOnly.FromDateTime(DateTime.Now).AddDays(-10), "Check 465");
            account.Withdraw(80m, DateOnly.FromDateTime(DateTime.Now).AddDays(-5), "Bank of The World");
            account.Withdraw(18.37m, DateOnly.FromDateTime(DateTime.Now).AddDays(0), "Bill's books");
            account.Withdraw(27.33m, DateOnly.FromDateTime(DateTime.Now).AddDays(5), "Mallgreens");

            transactions = account.GetList();
            return transactions;
        }

        // GET: <BankAccountController>
        //[HttpGet]
        //public async Task<List<Transaction>> Get()
        //{
        //    var account = new BankAccount("<name>", 1000);
        //    account.Withdraw(500, DateTime.Now, "Rent payment");
        //    account.Deposit(100, DateTime.Now, "friend paid me back");
        //    transactions = await Task.Run(() => account.GetList());
        //    return transactions;
        //}
    }
}
