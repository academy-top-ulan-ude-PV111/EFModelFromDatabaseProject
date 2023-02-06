using System;
using System.Collections.Generic;

namespace EFModelFromDatabaseProject.AppModel;

public partial class Company
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int CountryId { get; set; }

    public virtual Country Country { get; set; } = null!;

    public virtual ICollection<Employe> Employes { get; } = new List<Employe>();
}
