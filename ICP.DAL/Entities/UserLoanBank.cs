using System;
using System.Collections.Generic;

namespace ICP.DAL.Entities;

public partial class UserLoanBank
{
    public int LoanBankID { get; set; }

    public int LoanInfoID { get; set; }

    public string BankName { get; set; } = null!;

    public virtual UserLoanInfo LoanInfo { get; set; } = null!;
}
