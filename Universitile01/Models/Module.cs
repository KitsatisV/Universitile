using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;

namespace Universitile01.Models;

public partial class Module
{
	public Module(int moduleId, string moduleName, string moduleDescription, int moduleDuration, int coursesCourseId)
	{
		ModuleId = moduleId;
		ModuleName = moduleName;
		ModuleDescription = moduleDescription;
		ModuleDuration = moduleDuration;
		CoursesCourseId = coursesCourseId;
	}

	public Module()
	{
	}

	public int ModuleId { get; set; }

	public string ModuleName { get; set; } = null!;

	public string ModuleDescription { get; set; } = null!;

	public int ModuleDuration { get; set; }

	public int CoursesCourseId { get; set; }

  public string? Grade { get; set; }

  public virtual Course CoursesCourse { get; set; } = null!;

  public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();

  public virtual ICollection<Aspnetuser> Aspnetusers { get; set; } = new List<Aspnetuser>();
}

