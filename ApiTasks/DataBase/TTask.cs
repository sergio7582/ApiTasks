using System;
using System.Collections.Generic;

namespace ApiTasks.DataBase;

public partial class TTask
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Details { get; set; }

    public DateTime? Createat { get; set; }

    public DateTime? Limitdate { get; set; }

    public int? IdGroup { get; set; }

    public int? IdUser { get; set; }

    public int? IdStatus { get; set; }

    public virtual TGroup? IdGroupNavigation { get; set; }

    public virtual TStatus? IdStatusNavigation { get; set; }

    public virtual TUser? IdUserNavigation { get; set; }
}
