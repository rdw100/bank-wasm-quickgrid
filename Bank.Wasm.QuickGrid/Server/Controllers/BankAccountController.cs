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

        //        new Transaction(10886, "Wheels Dealership", "Debit", new DateOnly(2023, 3, 24), -780.32m, 2000.00m ),
        //        new Transaction(10887, "Pantry", "Debit", new DateOnly(2023, 3, 28), -100m, 2780.32m ),
        //        new Transaction(10888, "Pizza", "Debit", new DateOnly(2023, 3, 29), -25m, 2805.32m ),
        //        new Transaction(10889, "Deli", "Debit", new DateOnly(2023, 3, 30), -20m, 2825.32m),
        //        new Transaction(10890, "Bank of The World", "Withdrawal", new DateOnly(2023, 4, 13), -80m, 2745.32M),
        //        new Transaction(10891, "BART", "Debit", new DateOnly(2023, 4, 14), -20m, 2725.32m),
        //        new Transaction(10892, "The Cheese Board", "Debit", new DateOnly(2023, 4, 15), -11.05m, 2714.27m),
        //        new Transaction(10893, "Monterey Market", "Debit", new DateOnly(2023, 4, 15), -43.6m, 2670.67m),
        //        new Transaction(10894, "Bank of The World", "Deposit", new DateOnly(2023, 4, 15), 1711.68m, 4382.35m),
        //        new Transaction(10895, "Local 123", "Debit", new DateOnly(2023, 4, 16), -12.17m, 4307.18m),
        //        new Transaction(10896, "Check 465", "Check", new DateOnly(2023, 4, 17), -27.00m, 4343.18m),
        //        new Transaction(10897, "Bank of The World", "Withdrawal", new DateOnly(2023, 4, 17), -80.00m, 4263.18m),
        //        new Transaction(10898, "Bill's books", "Debit", new DateOnly(2023, 4, 19), -18.37m, 4244.81m),
        //        new Transaction(10899, "Balgreens", "Debit", new DateOnly(2023, 4, 20), -27.33m, 4217.48m)

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
