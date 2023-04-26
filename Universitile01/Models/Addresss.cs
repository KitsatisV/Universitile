using System;
using System.Collections.Generic;

namespace Universitile01.Models;

public partial class Addresss
{
    public int AddressId { get; set; }

    public string Address1 { get; set; } = null!;

    public string? Address2 { get; set; }

    public string City { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string ZipCode { get; set; } = null!;

    public string AspnetusersId { get; set; } = null!;

    public virtual Aspnetuser Aspnetusers { get; set; } = null!;
}
