using System;
using System.Collections.Generic;

namespace EFModelFromDatabaseProject.AppModel;

public partial class Employe
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int CompanyId { get; set; }

    public int PositionId { get; set; }

    public virtual Company Company { get; set; } = null!;

    public virtual Position Position { get; set; } = null!;
}
