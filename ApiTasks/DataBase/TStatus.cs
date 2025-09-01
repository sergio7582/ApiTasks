using System;
using System.Collections.Generic;

namespace ApiTasks.DataBase;

public partial class TStatus
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<TGroup> TGroups { get; set; } = new List<TGroup>();

    public virtual ICollection<TTask> TTasks { get; set; } = new List<TTask>();

    public virtual ICollection<TUser> TUsers { get; set; } = new List<TUser>();
}
