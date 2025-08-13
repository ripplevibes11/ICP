using System;
using System.Collections.Generic;

namespace ICP.DAL.Entities;

public partial class UserEmiratesInfo
{
    public int EmiratesInfoID { get; set; }

    public int UserID { get; set; }

    public string EmiratesID { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
