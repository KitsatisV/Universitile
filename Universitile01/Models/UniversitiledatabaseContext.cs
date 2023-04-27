using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Universitile01.Models;

public partial class UniversitiledatabaseContext : DbContext
{
    public UniversitiledatabaseContext()
    {
    }

    public UniversitiledatabaseContext(DbContextOptions<UniversitiledatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Addresss> Addressses { get; set; }

    public virtual DbSet<Announcement> Announcements { get; set; }

    public virtual DbSet<Aspnetrole> Aspnetroles { get; set; }

    public virtual DbSet<Aspnetroleclaim> Aspnetroleclaims { get; set; }

    public virtual DbSet<Aspnetuser> Aspnetusers { get; set; }

    public virtual DbSet<Aspnetuserclaim> Aspnetuserclaims { get; set; }

    public virtual DbSet<Aspnetuserlogin> Aspnetuserlogins { get; set; }

    public virtual DbSet<Aspnetusertoken> Aspnetusertokens { get; set; }

    public virtual DbSet<CalendarEvent> CalendarEvents { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<CourseLeader> CourseLeaders { get; set; }

    public virtual DbSet<Efmigrationshistory> Efmigrationshistories { get; set; }

    public virtual DbSet<Module> Modules { get; set; }

    public virtual DbSet<PerosnalInfo> PerosnalInfos { get; set; }

    public virtual DbSet<UsersHasAnnouncement> UsersHasAnnouncements { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=universtile.mysql.database.azure.com;user id=azureuser;password=7TI2K6O0O1ZL6SIUE6BDMGLDK*;database=universitiledatabase;sslmode=Required;sslca=C:\\Users\\tsimpuki\\Documents\\GitHub\\SIS_TP\\Universitile01\\DigiCertGlobalRootCA.crt.pem;tlsversion=\"TLS 1.2\"", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.32-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Addresss>(entity =>
        {
            entity.HasKey(e => new { e.AddressId, e.AspnetusersId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity
                .ToTable("addresss")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.AddressId, "address_id_UNIQUE").IsUnique();

            entity.HasIndex(e => e.AspnetusersId, "fk_addresss_aspnetusers1_idx");

            entity.Property(e => e.AddressId)
                .ValueGeneratedOnAdd()
                .HasColumnName("address_id");
            entity.Property(e => e.AspnetusersId)
                .HasColumnName("aspnetusers_Id")
                .UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.Address1)
                .HasMaxLength(120)
                .HasColumnName("address_1");
            entity.Property(e => e.Address2)
                .HasMaxLength(120)
                .HasColumnName("address_2");
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasMaxLength(100)
                .HasColumnName("country");
            entity.Property(e => e.ZipCode)
                .HasMaxLength(20)
                .HasColumnName("zip_code");

            entity.HasOne(d => d.Aspnetusers).WithMany(p => p.Addressses)
                .HasForeignKey(d => d.AspnetusersId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_addresss_aspnetusers1");
        });

        modelBuilder.Entity<Announcement>(entity =>
        {
            entity.HasKey(e => e.AnnouncementsId).HasName("PRIMARY");

            entity
                .ToTable("announcements")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.AnnouncementsId)
                .ValueGeneratedNever()
                .HasColumnName("announcements_id");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
        });

        modelBuilder.Entity<Aspnetrole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("aspnetroles");

            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<Aspnetroleclaim>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("aspnetroleclaims");

            entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            entity.HasOne(d => d.Role).WithMany(p => p.Aspnetroleclaims)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_AspNetRoleClaims_AspNetRoles_RoleId");
        });

        modelBuilder.Entity<Aspnetuser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("aspnetusers");

            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex").IsUnique();

            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.LockoutEnd).HasMaxLength(6);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "Aspnetuserrole",
                    r => r.HasOne<Aspnetrole>().WithMany()
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK_AspNetUserRoles_AspNetRoles_RoleId"),
                    l => l.HasOne<Aspnetuser>().WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_AspNetUserRoles_AspNetUsers_UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("aspnetuserroles");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<Aspnetuserclaim>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("aspnetuserclaims");

            entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.Aspnetuserclaims)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_AspNetUserClaims_AspNetUsers_UserId");
        });

        modelBuilder.Entity<Aspnetuserlogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("aspnetuserlogins");

            entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.ProviderKey).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.Aspnetuserlogins)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_AspNetUserLogins_AspNetUsers_UserId");
        });

        modelBuilder.Entity<Aspnetusertoken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

            entity.ToTable("aspnetusertokens");

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.Name).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.Aspnetusertokens)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_AspNetUserTokens_AspNetUsers_UserId");
        });

        modelBuilder.Entity<CalendarEvent>(entity =>
        {
            entity.HasKey(e => e.EventId).HasName("PRIMARY");

            entity
                .ToTable("calendar_events")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.EventId)
                .ValueGeneratedNever()
                .HasColumnName("event_id");
            entity.Property(e => e.DateEnd)
                .HasColumnType("datetime")
                .HasColumnName("date_end");
            entity.Property(e => e.DateStart)
                .HasColumnType("datetime")
                .HasColumnName("date_start");
            entity.Property(e => e.Description)
                .HasMaxLength(45)
                .HasColumnName("description");
            entity.Property(e => e.Tittle)
                .HasMaxLength(45)
                .HasColumnName("tittle");

            entity.HasMany(d => d.Aspnetusers).WithMany(p => p.CalendarEventsEvents)
                .UsingEntity<Dictionary<string, object>>(
                    "UsersHasCalendarEvent",
                    r => r.HasOne<Aspnetuser>().WithMany()
                        .HasForeignKey("AspnetusersId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_users_has_calendar_events_aspnetusers1"),
                    l => l.HasOne<CalendarEvent>().WithMany()
                        .HasForeignKey("CalendarEventsEventId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_users_has_calendar_events_calendar_events1"),
                    j =>
                    {
                        j.HasKey("CalendarEventsEventId", "AspnetusersId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j
                            .ToTable("users_has_calendar_events")
                            .HasCharSet("utf8mb3")
                            .UseCollation("utf8mb3_general_ci");
                        j.HasIndex(new[] { "AspnetusersId" }, "fk_users_has_calendar_events_aspnetusers1_idx");
                        j.HasIndex(new[] { "CalendarEventsEventId" }, "fk_users_has_calendar_events_calendar_events1_idx");
                        j.IndexerProperty<int>("CalendarEventsEventId").HasColumnName("calendar_events_event_id");
                        j.IndexerProperty<string>("AspnetusersId")
                            .HasColumnName("aspnetusers_Id")
                            .UseCollation("utf8mb4_0900_ai_ci")
                            .HasCharSet("utf8mb4");
                    });
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PRIMARY");

            entity
                .ToTable("courses")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.CourseDescription, "course_description_UNIQUE").IsUnique();

            entity.HasIndex(e => e.CourseId, "course_id_UNIQUE").IsUnique();

            entity.HasIndex(e => e.CourseName, "course_name_UNIQUE").IsUnique();

            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.CourseDescription)
                .HasMaxLength(250)
                .HasColumnName("course_description");
            entity.Property(e => e.CourseDuration).HasColumnName("course_duration");
            entity.Property(e => e.CourseName)
                .HasMaxLength(45)
                .HasColumnName("course_name");
        });

        modelBuilder.Entity<CourseLeader>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("course_leader")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.AspnetusersId, "fk_course_leader_aspnetusers1_idx");

            entity.HasIndex(e => e.CoursesCourseId, "fk_course_leader_courses1_idx");

            entity.Property(e => e.AspnetusersId)
                .HasColumnName("aspnetusers_Id")
                .UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.CoursesCourseId).HasColumnName("courses_course_id");

            entity.HasOne(d => d.Aspnetusers).WithMany()
                .HasForeignKey(d => d.AspnetusersId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_course_leader_aspnetusers1");

            entity.HasOne(d => d.CoursesCourse).WithMany()
                .HasForeignKey(d => d.CoursesCourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_course_leader_courses1");
        });

        modelBuilder.Entity<Efmigrationshistory>(entity =>
        {
            entity.HasKey(e => e.MigrationId).HasName("PRIMARY");

            entity.ToTable("__efmigrationshistory");

            entity.Property(e => e.MigrationId).HasMaxLength(150);
            entity.Property(e => e.ProductVersion).HasMaxLength(32);
        });

        modelBuilder.Entity<Module>(entity =>
        {
            entity.HasKey(e => new { e.ModuleId, e.CoursesCourseId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity
                .ToTable("modules")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.CoursesCourseId, "fk_modules_courses1_idx");

            entity.HasIndex(e => e.ModuleDescription, "module_description_UNIQUE").IsUnique();

            entity.HasIndex(e => e.ModuleId, "module_id_UNIQUE").IsUnique();

            entity.HasIndex(e => e.ModuleName, "module_name_UNIQUE").IsUnique();

            entity.Property(e => e.ModuleId)
                .ValueGeneratedOnAdd()
                .HasColumnName("module_id");
            entity.Property(e => e.CoursesCourseId).HasColumnName("courses_course_id");
            entity.Property(e => e.ModuleDescription)
                .HasMaxLength(250)
                .HasColumnName("module_description");
            entity.Property(e => e.ModuleDuration).HasColumnName("module_duration");
            entity.Property(e => e.ModuleName)
                .HasMaxLength(45)
                .HasColumnName("module_name");

            entity.HasOne(d => d.CoursesCourse).WithMany(p => p.Modules)
                .HasForeignKey(d => d.CoursesCourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_modules_courses1");

            entity.HasMany(d => d.Aspnetusers).WithMany(p => p.ModulesModules)
                .UsingEntity<Dictionary<string, object>>(
                    "Student",
                    r => r.HasOne<Aspnetuser>().WithMany()
                        .HasForeignKey("AspnetusersId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_modules_has_aspnetusers_aspnetusers1"),
                    l => l.HasOne<Module>().WithMany()
                        .HasPrincipalKey("ModuleId")
                        .HasForeignKey("ModulesModuleId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_modules_has_aspnetusers_modules1"),
                    j =>
                    {
                        j.HasKey("ModulesModuleId", "AspnetusersId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j
                            .ToTable("students")
                            .HasCharSet("utf8mb3")
                            .UseCollation("utf8mb3_general_ci");
                        j.HasIndex(new[] { "AspnetusersId" }, "fk_modules_has_aspnetusers_aspnetusers1_idx");
                        j.HasIndex(new[] { "ModulesModuleId" }, "fk_modules_has_aspnetusers_modules1_idx");
                        j.IndexerProperty<int>("ModulesModuleId").HasColumnName("modules_module_id");
                        j.IndexerProperty<string>("AspnetusersId")
                            .HasColumnName("aspnetusers_Id")
                            .UseCollation("utf8mb4_0900_ai_ci")
                            .HasCharSet("utf8mb4");
                    });
        });

        modelBuilder.Entity<PerosnalInfo>(entity =>
        {
            entity.HasKey(e => new { e.InfoId, e.AspnetusersId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity
                .ToTable("perosnal_info")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.AspnetusersId, "fk_perosnal_info_aspnetusers1_idx");

            entity.HasIndex(e => e.InfoId, "info_id_UNIQUE").IsUnique();

            entity.Property(e => e.InfoId)
                .ValueGeneratedOnAdd()
                .HasColumnName("info_id");
            entity.Property(e => e.AspnetusersId)
                .HasColumnName("aspnetusers_Id")
                .UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.DateOfBirth)
                .HasColumnType("datetime")
                .HasColumnName("date_of_birth");
            entity.Property(e => e.FirstName)
                .HasMaxLength(45)
                .HasColumnName("first_name");
            entity.Property(e => e.Landline)
                .HasMaxLength(20)
                .HasColumnName("landline");
            entity.Property(e => e.LastName)
                .HasMaxLength(45)
                .HasColumnName("last_name");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(45)
                .HasColumnName("middle_name");
            entity.Property(e => e.Mobile)
                .HasMaxLength(20)
                .HasColumnName("mobile");
            entity.Property(e => e.Sex).HasColumnName("sex");

            entity.HasOne(d => d.Aspnetusers).WithMany(p => p.PerosnalInfos)
                .HasForeignKey(d => d.AspnetusersId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_perosnal_info_aspnetusers1");
        });

        modelBuilder.Entity<UsersHasAnnouncement>(entity =>
        {
            entity.HasKey(e => new { e.AnnouncementsAnnouncementsId, e.AspnetusersId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity
                .ToTable("users_has_announcements")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.AnnouncementsAnnouncementsId, "fk_users_has_announcements_announcements1_idx");

            entity.HasIndex(e => e.AspnetusersId, "fk_users_has_announcements_aspnetusers1_idx");

            entity.Property(e => e.AnnouncementsAnnouncementsId).HasColumnName("announcements_announcements_id");
            entity.Property(e => e.AspnetusersId)
                .HasColumnName("aspnetusers_Id")
                .UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.IsRead).HasColumnName("is_read");

            entity.HasOne(d => d.AnnouncementsAnnouncements).WithMany(p => p.UsersHasAnnouncements)
                .HasForeignKey(d => d.AnnouncementsAnnouncementsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_users_has_announcements_announcements1");

            entity.HasOne(d => d.Aspnetusers).WithMany(p => p.UsersHasAnnouncements)
                .HasForeignKey(d => d.AspnetusersId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_users_has_announcements_aspnetusers1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
