using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC_Project.Models;

public partial class PayRoll
{
    [Key]
    public int Id { get; set; }

    public string? Empname { get; set; }

    public string? Deptname { get; set; }

    public string? Email { get; set; }

    public int? Accno { get; set; }

    public int? Leavedays { get; set; }

    public int? Detuction { get; set; }

    public int? Salary { get; set; }
}
