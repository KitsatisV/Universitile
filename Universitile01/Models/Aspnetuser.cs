using System;
using System.Collections.Generic;

namespace Universitile01.Models;

public partial class Aspnetuser
{
    public string Id { get; set; } = null!;

    public string? UserName { get; set; }

    public string? NormalizedUserName { get; set; }

    public string? Email { get; set; }

    public string? NormalizedEmail { get; set; }

    public bool EmailConfirmed { get; set; }

    public string? PasswordHash { get; set; }

    public string? SecurityStamp { get; set; }

    public string? ConcurrencyStamp { get; set; }

    public string? PhoneNumber { get; set; }

    public bool PhoneNumberConfirmed { get; set; }

    public bool TwoFactorEnabled { get; set; }

    public DateTime? LockoutEnd { get; set; }

    public bool LockoutEnabled { get; set; }

    public int AccessFailedCount { get; set; }

    public virtual ICollection<Addresss> Addressses { get; set; } = new List<Addresss>();

    public virtual ICollection<Aspnetuserclaim> Aspnetuserclaims { get; set; } = new List<Aspnetuserclaim>();

    public virtual ICollection<Aspnetuserlogin> Aspnetuserlogins { get; set; } = new List<Aspnetuserlogin>();

    public virtual ICollection<Aspnetusertoken> Aspnetusertokens { get; set; } = new List<Aspnetusertoken>();

    public virtual ICollection<PerosnalInfo> PerosnalInfos { get; set; } = new List<PerosnalInfo>();

    public virtual ICollection<UsersHasAnnouncement> UsersHasAnnouncements { get; set; } = new List<UsersHasAnnouncement>();

    public virtual ICollection<CalendarEvent> CalendarEventsEvents { get; set; } = new List<CalendarEvent>();

    public virtual ICollection<Module> ModulesModules { get; set; } = new List<Module>();

    public virtual ICollection<Aspnetrole> Roles { get; set; } = new List<Aspnetrole>();
}
