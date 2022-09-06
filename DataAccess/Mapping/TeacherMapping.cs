using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapping
{
    public class TeacherMapping: EntityTypeConfiguration<Teacher>
    {
        // Teacher mapping classında, Teacher classındaki propların SQL'deki özelliklerini ayarlıyoruz. Identity olma, max karakter sayısı
        public TeacherMapping()
        {
            this.HasKey(t => t.ID); //Teacherclassı içinde ID propertysini primary key olarak ayarladık.
            this.Property(t=>t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
            // Id kolonunu identity yaptık ve boş geçilmez oldg söylüyor.

            this.Property(t => t.FirstName).HasMaxLength(25).HasColumnType("nvarchar");
            //HasColumnType'da vereceğin kolon tipi SQL içinde yazıldığı gibi

            //Bir öğretmen ilişkisi
            //Öğretmenin bir okulu olur, okulun birden fazla öğretmeni olur, Bunlarda SchoolID üzerinden bağlanır.

            this.HasRequired(t => t.School)
                .WithMany(s => s.Teachers)
                .HasForeignKey(t => t.SchoolID);

        }
    }
}
