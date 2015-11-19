using OneDice.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneDice.EntityFramework.Mapping
{
    public class ScoreMap : EntityTypeConfiguration<Score>
    {
        public ScoreMap ()
	    {
            HasKey(t => t.ID);
	    }
        
    }
}
