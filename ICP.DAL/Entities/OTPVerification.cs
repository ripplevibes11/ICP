using System;
using System.Collections.Generic;

namespace ICP.DAL.Entities;

public partial class OTPVerification
{
    public int OTPID { get; set; }

    public int UserID { get; set; }

    public string OTPCode { get; set; } = null!;

    public bool? IsVerified { get; set; }

    public DateTime? SentAt { get; set; }

    public virtual User User { get; set; } = null!;
}
