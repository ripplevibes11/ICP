using System;
using System.Collections.Generic;

namespace ICP.DAL.Entities;

public partial class User
{
    public int UserID { get; set; }

    public string FullName { get; set; } = null!;

    public bool IsUaePassRegistered { get; set; }

    public string MobileNumber { get; set; } = null!;

    public string EmailAddress { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public string CategoryName { get; set; } = null!;

    public virtual ICollection<OTPVerification> OTPVerifications { get; set; } = new List<OTPVerification>();

    public virtual ICollection<UserCreditCard> UserCreditCards { get; set; } = new List<UserCreditCard>();

    public virtual ICollection<UserDebitCard> UserDebitCards { get; set; } = new List<UserDebitCard>();

    public virtual ICollection<UserEmiratesInfo> UserEmiratesInfos { get; set; } = new List<UserEmiratesInfo>();

    public virtual ICollection<UserLoanInfo> UserLoanInfos { get; set; } = new List<UserLoanInfo>();
}
