using System;
using System.Collections.Generic;

namespace Universitile01.Models;

public partial class PersonalInfo
{
    public int InfoId { get; set; }

    public DateOnly DateOfBirth { get; set; }

    public sbyte Sex { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string? Landline { get; set; }

    public string Mobile { get; set; } = null!;

    public string AspnetusersId { get; set; } = null!;

    public virtual Aspnetuser Aspnetusers { get; set; } = null!;
}
