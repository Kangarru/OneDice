using OneDice.Logic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OneDice.Controllers
{
    public class ImageController : Controller
    {
        // GET: Image
        public ActionResult Upload()
        {
            return PartialView();
        }

        [HttpPost]
        public string Upload(HttpPostedFileBase file)
        {
            try
            {
                HttpFileCollection hfc = System.Web.HttpContext.Current.Request.Files;
                string userId = AppCookies.getCookie(AppCookies.UserId);
                string path = "~/images/" + userId + "/";
                string thumbNailPath = "~/thumbnails/" + userId + "/";
                Directory.CreateDirectory(Server.MapPath(path));
                Directory.CreateDirectory(Server.MapPath(thumbNailPath));
                for (int i = 0; i < hfc.Count; i++)
                {
                    HttpPostedFile hpf = hfc[i];
                    if (hpf.ContentLength > 0)
                    {
                        string fileName = "";
                        if (Request.Browser.Browser == "IE")
                        {
                            fileName = Path.GetFileName(hpf.FileName);
                        }
                        else
                        {
                            fileName = hpf.FileName;
                        }
                        if (!(fileName.EndsWith(".jpg", StringComparison.CurrentCultureIgnoreCase) | fileName.EndsWith(".png", StringComparison.CurrentCultureIgnoreCase) | fileName.EndsWith(".gif", StringComparison.CurrentCultureIgnoreCase)))
                        {
                            return "{error: 'File format not supported. Permitted files[.jpg, .png, .gif]'}";
                        }
                        string fullPathWithFileName = path + fileName;
                        string fullThumbNailPath = thumbNailPath + fileName;
                        int j = 0;
                        while (System.IO.File.Exists(Server.MapPath(fullPathWithFileName)))
                        {
                            j++;
                            var fileNameWithoutExtension = fileName.Split('.')[0];
                            fileNameWithoutExtension += j == 1 ? j.ToString() : fileNameWithoutExtension.Substring(0, fileNameWithoutExtension.Length - j.ToString().Length) + j.ToString();
                            fullPathWithFileName = path + fileNameWithoutExtension + "." + fileName.Split('.')[1];
                            fullThumbNailPath = thumbNailPath + fileNameWithoutExtension + "." + fileName.Split('.')[1];
                        }
                        hpf.SaveAs(Server.MapPath(fullPathWithFileName));
                        GenerateThumbnail(Server.MapPath(fullPathWithFileName), Server.MapPath(fullThumbNailPath));
                    }
                }
                return "{}";
            }
            catch (Exception ex)
            {
                return "{error: '" + ex.Message + "'}";
            }
        }

        public ActionResult Manage()
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
            return PartialView();
        }

        [HttpPost]
        public ActionResult Manage(string page, string key)
        {
            key = key ?? "";
            string userId = AppCookies.getCookie(AppCookies.UserId);
            string path = "~/images/" + userId + "/";
            var Images = Directory.EnumerateFiles(Server.MapPath(path), "*.gif").ToList();
            Images.AddRange(Directory.EnumerateFiles(Server.MapPath(path), "*.png").ToList());
            Images.AddRange(Directory.EnumerateFiles(Server.MapPath(path), "*.jpg").ToList());
            Images = Images.Select(x => x.Replace(Server.MapPath(path), "")).Where(x => x.ToLower().Contains(key.ToLower())).ToList();
            ViewBag.Count = Images.Count;
            int skip = Convert.ToInt32(page) <= 0 ? 0 : Convert.ToInt32(page) - 1;
            ViewBag.Images = Images.Skip(skip * 16).Take(16).ToList();
            ViewBag.CurrentPage = Convert.ToInt32(page);
            ViewBag.Key = key;
            ViewBag.UserId = userId;
            return PartialView("ImageList");
        }

        [HttpPost]
        public ActionResult Delete(string imageToDelete)
        {
            string userId = AppCookies.getCookie(AppCookies.UserId);
            string path = "~/images/" + userId + "/" +imageToDelete;
            string thumbnailPath = "~/images/" + userId + "/" +imageToDelete;
            System.IO.File.Delete(Server.MapPath(path));
            System.IO.File.Delete(Server.MapPath(thumbnailPath));

            path = "~/images/" + userId + "/";
            var Images = Directory.EnumerateFiles(Server.MapPath(path), "*.gif").ToList();
            Images.AddRange(Directory.EnumerateFiles(Server.MapPath(path), "*.png").ToList());
            Images.AddRange(Directory.EnumerateFiles(Server.MapPath(path), "*.jpg").ToList());
            Images = Images.Select(x => x.Replace(Server.MapPath(path), "")).ToList();
            ViewBag.Count = Images.Count;
            ViewBag.Images = Images.Take(16).ToList();
            ViewBag.CurrentPage = 1;
            ViewBag.UserId = userId;
            return PartialView("ImageList");
        }

        [NonAction]
        public static void GenerateThumbnail(string originalImagePath, string thumbnailImagePath)
        {
            Image img = Image.FromFile(originalImagePath);
            int thumbnailsize = 80;
            int width;
            int height;
            var originalImage = new Bitmap(img);

            if (originalImage.Width > originalImage.Height)
            {
                width = thumbnailsize;
                height = thumbnailsize * originalImage.Height / originalImage.Width;
            }
            else
            {
                height = thumbnailsize;
                width = thumbnailsize * originalImage.Width / originalImage.Height;
            }

            Bitmap thumbnailImage = null;
            try
            {
                thumbnailImage = new Bitmap(width, height);

                using (Graphics graphics = Graphics.FromImage(thumbnailImage))
                {
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    graphics.DrawImage(originalImage, 0, 0, width, height);
                }

                thumbnailImage.Save(thumbnailImagePath);
            }
            finally
            {
                if (thumbnailImage != null)
                {
                    thumbnailImage.Dispose();
                }
            }
        }
    }
}