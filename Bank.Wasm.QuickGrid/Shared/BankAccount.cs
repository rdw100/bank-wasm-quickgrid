﻿namespace Bank.Wasm.QuickGrid.Shared;

public record BankAccount
{
    private static uint _number = 1234567890;
    private List<Transaction> transactions = new List<Transaction>();
     
    public uint Number 
    { 
        get => _number;
        init { _number = value; }
    }

    public string Owner { get; set; }
    public decimal Balance
    {
        get
        {
            decimal balance = 0;
            for (int tx = 0; tx < transactions.Count; tx++)
            {
                Transaction? item = transactions[tx];
                balance += item.Amount;
            }

            return balance;
        }
    }   

    public BankAccount(string name, DateOnly date, decimal initialBalance)
    {
        Number++;

        Owner = name;
        OpenDeposit(initialBalance, date, "Initial balance");
    }

    public void OpenDeposit(decimal amount, DateOnly date, string note)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
        }
        var deposit = new Transaction(amount, amount, date, note, TransactionType.Deposit);
        transactions.Add(deposit);
    }

    public void Deposit(decimal amount, DateOnly date, string note)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
        }
        var deposit = new Transaction(amount, Balance, date, note, TransactionType.Deposit);
        transactions.Add(deposit);
    }

    public void Withdraw(decimal amount, DateOnly date, string note)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
        }
        if (Balance - amount < 0)
        {
            throw new InvalidOperationException("Not sufficient funds for this withdrawal");
        }
        var withdrawal = new Transaction(-amount, Balance, date, note, TransactionType.Withdraw);
        transactions.Add(withdrawal);
    }

    public string Print()
    {
        var report = new System.Text.StringBuilder();

        decimal balance = 0;
        report.AppendLine("Date\t\tId\tType\tAmount\tBalance\tNote");
        foreach (var item in transactions)
        {
            balance += item.Amount;
            report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Id}\t{item.Type} {item.Amount}\t{balance}\t{item.Description}");
        }

        return report.ToString();
    }

    public async Task<List<Transaction>> GetQuery()
    {
        return await Task.Run(() => transactions);
    }

    public List<Transaction> GetList()
    {
        return transactions;
    }
}