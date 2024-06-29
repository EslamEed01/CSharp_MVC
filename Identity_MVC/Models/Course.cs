using System;
using System.Collections.Generic;

namespace Identity_MVC.Models;

public partial class Course
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int MinDegree { get; set; }

    public int Degree { get; set; }

    public int? DepId { get; set; }

    public virtual Department? Dep { get; set; }
}
