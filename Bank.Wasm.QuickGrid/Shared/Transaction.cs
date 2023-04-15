namespace Bank.Wasm.QuickGrid.Shared;

public record Transaction
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
    public decimal Balance { get; }
    public DateOnly Date { get; }
    public string Description { get; } = string.Empty;
    public TransactionType Type { get; set; }
    public Transaction() { }
    public Transaction(decimal amount, decimal balance, DateOnly date, string description, TransactionType txType)
    {
        Id = _id;
        Amount = amount;
        Balance = balance;
        Date = date;
        Type = txType;
        Description = description;
    }
}