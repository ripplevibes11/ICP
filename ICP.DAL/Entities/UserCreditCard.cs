using System;
using System.Collections.Generic;

namespace ICP.DAL.Entities;

public partial class UserCreditCard
{
    public int CreditCardID { get; set; }

    public int UserID { get; set; }

    public string CardNumber { get; set; } = null!;

    public string ExpiryDate { get; set; } = null!;

    public string CVV { get; set; } = null!;

    public decimal AvailableBalance { get; set; }

    public virtual User User { get; set; } = null!;
}
