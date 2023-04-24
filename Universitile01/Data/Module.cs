using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.AspNetCore.Identity;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Reflection.PortableExecutable;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net.NetworkInformation;
using MySqlConnector;
using System.Data.SqlClient;




namespace Universitile01.Data
{


    public class Module
    {

        [Key]
        [Column("module_id")]
        public int ModuleId { get; set; }

        [Column("module_name")]
        public string Name { get; set; }

        [Column("module_description")]
        public string Description { get; set; }

        [Column("module_duration")]
        public int Duration { get; set; }

       // [Column("teacher_user_id")]
        //public string TeacherUserId { get; set; }


       // [ForeignKey("TeacherUserId")]
        //public virtual IdentityUser TeacherUser { get; set; }

        public Module() { }

        public Module(int module_id, string module_name, string module_description, int module_duration) //string teacher_user_id)
        {
            ModuleId = module_id;
            Name = module_name;
            Description = module_description;
            Duration = module_duration;
            //TeacherUserId = teacher_user_id;
        }
    }
}

