using System;
using System.Collections.Generic;

namespace EFModelFromDatabaseProject.AppModel;

public partial class Position
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<Employe> Employes { get; } = new List<Employe>();
}
