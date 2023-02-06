using System;
using System.Collections.Generic;

namespace EFModelFromDatabaseProject.AppModel;

public partial class Country
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<Company> Companies { get; } = new List<Company>();
}
