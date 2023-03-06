using System;
using System.Collections.Generic;

namespace testWeb.Models;

public partial class Directory
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? IdParentDirectory { get; set; }
    public virtual Directory Parent { get; set; }
    public virtual ICollection<Directory> Children { get; set; }
}
