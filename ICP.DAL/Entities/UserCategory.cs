using System;
using System.Collections.Generic;

namespace ICP.DAL.Entities;

public partial class UserCategory
{
    public int CategoryID { get; set; }

    public string CategoryName { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
