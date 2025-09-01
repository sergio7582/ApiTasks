using System;
using System.Collections.Generic;

namespace ApiTasks.DataBase;

public partial class TGroup
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Icon { get; set; }

    public DateTime? Createat { get; set; }

    public int? IdStatus { get; set; }

    public int? IdUser { get; set; }

    public virtual TStatus? IdStatusNavigation { get; set; }

    public virtual TUser? IdUserNavigation { get; set; }

    public virtual ICollection<TTask> TTasks { get; set; } = new List<TTask>();
}
