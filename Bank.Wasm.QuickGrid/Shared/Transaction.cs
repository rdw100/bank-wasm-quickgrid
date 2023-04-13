using System.Formats.Asn1;

namespace Bank.Wasm.QuickGrid.Shared;

public class Transaction
{
    private static uint _nextId = 12345;
    private uint _id;
    public uint Id 
    { 
        get => _id; 
        set 
        {
            _nextId++;
            _id = _nextId;
        }
    }    

    public decimal Amount { get; }
    public DateTime Date { get; }
    public string Description { get; }
    public TransactionType Type { get; set; }

    public Transaction(decimal amount, DateTime date, TransactionType txType, string description)
    {
        Id = _id;
        Amount = amount;
        Date = date;
        Type = txType;
        Description = description;
    }
}

public enum TransactionType
{ 
    Withdraw = 0,
    Deposit = 1,
    Check = 2,
    Debit = 3
}
