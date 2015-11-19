using OneDice.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneDice.EntityFramework.Mapping
{
    public class EntityMap<T> : EntityTypeConfiguration<T> where T : Entity
    {
        public EntityMap()
        {
            HasKey(t => t.ID);
            Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.DateCreated).IsRequired();
            Property(t => t.DateUpdated).IsRequired();
            Property(t => t.IsDeactivated).IsRequired();
            Property(t => t.IsDeleted).IsRequired();
            Property(t => t.Name).IsRequired();
        }
    }
}
