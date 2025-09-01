using System;
using System.Collections.Generic;

namespace ApiTasks.DataBase;

public partial class TUser
{
    public int Id { get; set; }

    public string? Username { get; set; }

    public string? Name { get; set; }

    public string? Lastname { get; set; }

    public DateTime? Createat { get; set; }

    public DateTime? Lastlogindate { get; set; }

    public string? Email { get; set; }

    public int? Idstatus { get; set; }

    public string? Password { get; set; }

    public int? Verified { get; set; }

    public virtual TStatus? IdstatusNavigation { get; set; }

    public virtual ICollection<TGroup> TGroups { get; set; } = new List<TGroup>();

    public virtual ICollection<TTask> TTasks { get; set; } = new List<TTask>();
}
