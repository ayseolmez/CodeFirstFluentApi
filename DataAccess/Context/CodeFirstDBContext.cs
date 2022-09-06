using DataAccess.Mapping;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class CodeFirstDBContext : DbContext
    {
        public CodeFirstDBContext() : base("Server =LAPTOP-E9EUVB10\\MSSQLSERVER2019;Database=KD12CodeFirstAppTekrarDB;Uid=sa;Pwd=1234;")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<CodeFirstDBContext>());
            //Eğer senin db veri tabanında yoksa onu yaratacak. Yazmasak da yapıyor default.
        }

        public DbSet<Teacher> teachers { get; set; }
        public DbSet<School> schools { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new TeacherMapping());
            modelBuilder.Configurations.Add(new SchoolMapping());

            //Ayarladığımız düzenlemelerizi veritabanına yansıtılacağını söyledm.
        }
    }
}
