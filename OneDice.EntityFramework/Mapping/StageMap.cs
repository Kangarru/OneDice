using OneDice.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneDice.EntityFramework.Mapping
{
    public class StageMap : EntityTypeConfiguration<Stage>
    {
        public StageMap ()
	    {
            HasKey(t => t.ID);
	    }
    }
}
