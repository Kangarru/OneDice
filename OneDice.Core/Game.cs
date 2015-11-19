using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneDice.Core
{
    public class Game : Entity
    {
        //Details -> Grouping -> Scoring -> multimedia
        /// <summary>
        /// closest akin to a known game for user profiling
        /// </summary>
        public string GameType { get; set; }
        public int NumberOfTeams { get; set; }
        public string Description { get; set; }
        public List<Stage> Stages { get; set; }
        public Score ScoreParams { get; set; }
        public string UserId { get; set; }
        public string LiveStreamUrl { get; set; }
        public string BannerImages { get; set; }
        public string Avatar { get; set; }
        public string StageListJson { get; set; }
        public string ScoreJson { get; set; }
    }
}
