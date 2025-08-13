using System;
using System.Collections.Generic;

namespace ICP.DAL.Entities;

public partial class UserLoanInfo
{
    public int LoanInfoID { get; set; }

    public int UserID { get; set; }

    public bool HasLoan { get; set; }

    public int? NumberOfAccounts { get; set; }

    public string? VerificationMethod { get; set; }

    public virtual User User { get; set; } = null!;

    public virtual ICollection<UserLoanBank> UserLoanBanks { get; set; } = new List<UserLoanBank>();
}
