using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OneDice.Controllers
{
    public class DataController : Controller
    {
        // GET: Data
        public JsonResult Games()
        {
            var s = Json(LoadJson());
            return s;
        }
        public List<string> LoadJson()
        {
            using (StreamReader r = new StreamReader(Server.MapPath("~/App_Data/games.json")))
            {
                string json = r.ReadToEnd();
                List<Game> items = JsonConvert.DeserializeObject<List<Game>>(json);
                return items.Select(x => x.value).ToList();
            }
        }
        class Game
        {
            public string value { get; set; }
            public List<string> tokens { get; set; }
            public string permalink { get; set; }
        }
    }
}