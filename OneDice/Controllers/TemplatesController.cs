using Newtonsoft.Json;
using OneDice.Core;
using OneDice.EntityFramework;
using OneDice.Logic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OneDice.Controllers
{
    public class TemplatesController : Controller
    {
        // GET: Templates
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Dashboard()
        {
            ViewBag.User = UserLogic.VerifyUser(AppCookies.getCookie(AppCookies.UserId));
            return View();
        }

        public ActionResult AddTournament()
        {
            ViewBag.User = UserLogic.VerifyUser(AppCookies.getCookie(AppCookies.UserId));
            return View();
        }

        public ActionResult ViewTournaments()
        {
            ViewBag.User = UserLogic.VerifyUser(AppCookies.getCookie(AppCookies.UserId));
            return View();
        }

        [HttpGet]
        public ActionResult AddGame(string id)
        {
            SetImageCountToViewBag();
            Game model = new Game();
            ViewBag.User = UserLogic.VerifyUser(AppCookies.getCookie(AppCookies.UserId));
            return View(model);
        }

        [HttpPost]
        public string AddGame(FormCollection form)
        {
            try
            {
                var dao = new GameDAO();
                Game model = new Game();
                //if edit
                if (string.IsNullOrWhiteSpace(form["game-id"]))
                {
                    model = dao.Table.Where(x => x.UserId == AppCookies.UserId && x.ID == Convert.ToInt32(form["game-id"])).FirstOrDefault();
                    if (model == null) throw new Exception("Game not found");
                }
                //step 1
                model.Name = form["game-name"];
                model.UserId = AppCookies.UserId;
                model.GameType = form["game-game"];
                model.Description = form["game-description"];
                //step 2
                string[] stages = form.AllKeys.Where(x => x.StartsWith("ingress-")).Select(x => x.Split('-')[1]).ToArray();
                
                string[] competitionTypes = form["competitiontype-" + stages[0]].Split(',').ToArray();
                int index = -1;
                model.Stages = new List<Stage>();
                foreach (var stage in stages)
                {
                    index++;
                    Stage new_stage = new Stage();
                    
                    CompetitionType c_type = (CompetitionType)Convert.ToInt32(competitionTypes[index]);
                    new_stage.CompetitionType = c_type;
                    new_stage.Egress = Convert.ToInt32(form["egress-" + stage]);
                    new_stage.Ingress = Convert.ToInt32(form["ingress-" + stage]);
                    model.Stages.Add(new_stage);
                }
                model.StageListJson = JsonConvert.SerializeObject(model.Stages);
                //step 3
                Score score = new Score();
                ScoringType s_type = (ScoringType)Convert.ToInt32(form["score-type"]);
                score.ScoringType = s_type;
                if (s_type != ScoringType.Percentage)
                {
                    score.Ranged = form["has-range"] == "on" ? true : false;
                    if (score.Ranged)
                    {
                        score.Minimum = Convert.ToDecimal(form["minimum-score"]);
                        score.Maximum = Convert.ToDecimal(form["maximum-score"]);
                    }
                }
                model.ScoreParams = score;
                model.ScoreJson = JsonConvert.SerializeObject(model.ScoreParams);
                //step 4
                model.LiveStreamUrl = form["live-video-stream"];
                model.BannerImages = form["banner-images"];
                model.Avatar = form["game-avatar"];

                //save or update
                model.DateUpdated = DateTime.Now;
                if(model.ID == 0)//save
                {
                    model.DateCreated = DateTime.Now;
                    dao.Save(model);
                }
                else //update
                {
                    dao.Update(model);
                }
                return AppConstants.SuccessBigBox("Game Setup Successful!", "templates/addgame");
            }
            catch(Exception e)
            {
                string fullExceptionMessage = e.Message + " ";
                if (e.InnerException != null)
                {
                    fullExceptionMessage += e.InnerException.Message;
                }
                return AppConstants.ErrorBigBox(fullExceptionMessage, "templates/addgame");
            }
            
        }

        public ActionResult ViewGames()
        {
            ViewBag.User = UserLogic.VerifyUser(AppCookies.getCookie(AppCookies.UserId));
            return View();
        }

        [NonAction]
        public void SetImageCountToViewBag()
        {
            string userId = AppCookies.getCookie(AppCookies.UserId);
            string path = "~/images/" + userId + "/";
            var Images = Directory.EnumerateFiles(Server.MapPath(path), "*.gif").ToList();
            Images.AddRange(Directory.EnumerateFiles(Server.MapPath(path), "*.png").ToList());
            Images.AddRange(Directory.EnumerateFiles(Server.MapPath(path), "*.jpg").ToList());
            Images = Images.Select(x => x.Replace(Server.MapPath(path), "")).ToList();
            ViewBag.Count = Images.Count;
            ViewBag.Images = Images.Take(16).ToList();
            ViewBag.CurrentPage = 1;
            ViewBag.Key = "";
            ViewBag.UserId = userId;
        }
    }
}