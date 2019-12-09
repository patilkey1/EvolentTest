using DBMapper.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMapper.Mapping
{
    public class ContactInfoMap : EntityTypeConfiguration<ContactInfo>
    {
        public ContactInfoMap()
        {
            HasKey(m => m.ID);
            Property(m => m.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(m => m.firstName).IsRequired().HasMaxLength(255);
            Property(m => m.lastName).IsRequired().HasMaxLength(255);
            Property(m => m.Email).IsRequired().HasMaxLength(255);
            Property(m => m.PhoneNumber).IsRequired().HasMaxLength(255);
            Property(m => m.isActive).IsRequired();

            ToTable("tb_trnContactInfo");
        }
    }
}
