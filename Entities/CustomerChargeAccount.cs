using ChargeAccountManager.Enums;

namespace ChargeAccountManager.Entities;

public class CustomerChargeAccount
{
    /// <summary>
    /// /Customer id
    /// </summary>
    public required string CustomerId { get; set; }
    /// <summary>
    /// Has some debt
    /// </summary>
    public bool HasDebt { get; set; }
    /// <summary>
    /// Product type
    /// </summary>
    public ProductType? ProductType { get; set; }
    /// <summary>
    /// Account status
    /// </summary>
    public AccountStatus? AccountStatus { get; set; }
    /// <summary>
    /// Debt ammount
    /// </summary>
    public decimal DebdAmmount { get; set; }
    /// <summary>
    /// Balance
    /// </summary>
    public decimal Balance { get; set; }
    public required string Data { get; set; }
}