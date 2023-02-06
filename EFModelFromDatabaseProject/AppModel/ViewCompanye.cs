using System;
using System.Collections.Generic;

namespace EFModelFromDatabaseProject.AppModel;

public partial class ViewCompanye
{
    public string CompanyTitle { get; set; } = null!;

    public int? EmployesCount { get; set; }
}
