using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneDice.Logic
{
    public class AppConfigurations
    {
        public static string TweetUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["TweetUrl"];
            }
        }
        public static string ServerUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["ServerUrl"];
            }
        }
    }
}
