using OneDice.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneDice.EntityFramework.Mapping
{
    public class GameMap : EntityMap<Game>
    {
        public GameMap()
        {
            Ignore(t => t.Stages);
            Ignore(t => t.ScoreParams);
        }
    }
}
