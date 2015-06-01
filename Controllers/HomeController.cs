using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ufight.Models;
using BotDetect.Web.UI.Mvc;
using MySql.Data.MySqlClient;
using Ufight.Repository;

namespace Ufight.Controllers
{
    public class HomeController : Controller
    {
        private UfightRepository repository = new UfightRepository();

        public HomeController()
        {


        }

        public ActionResult Index()
        {
            //MySqlConnection connection = new MySqlConnection();
            //connection.ConnectionString = "Server=84.246.4.143;Port=9133;Database=Fong_ufight;Uid=Fong_admin;Pwd=A97tuuriy;";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Under Construction.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact.";

            return View();
        }
        /// <summary>
        /// View
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AanMelden(UserModel model)
        {
            ViewBag.Error = "";
            bool succes = false;
            if (ModelState.IsValid)
            {
               
                try
                {
                    repository.AddUser(model);
                    succes = true;
                }
                catch
                {
                    //Do Some Error handeling

                }
                //using (UfightDataContext db = new UfightDataContext())
                //{
                //    User user = new User();
                //    user.Email = model.Email;
                //    user.Land = model.Land;
                //    user.Password = model.Password;
                //    user.Postcode = model.PostCode;
                //    user.RegDate = DateTime.Now;
                //    user.SportSchool = model.SportSchool;
                //    user.StraatNaam = model.StraatNaam;
                //    user.Username = model.UserName;
                //    user.Role = 2;
                //    user.Plaats = model.Plaats;

                //    try
                //    {
                //        db.Users.InsertOnSubmit(user);
                //        db.SubmitChanges();
                //    }
                //    catch (Exception ex)
                //    {
                //        throw new Exception(ex.Message);
                //    }

                // }
            }
            if (succes)
            {
                return View("AfterAanMelden");
            }
            ViewBag.Error = "Error, Aanmelden niet gelukt. Mogelijk uw gekozen usernaam is niet meer beschikbaar";
            return View("AanMelden");
        }

        /// <summary>
        /// You get this view/action when you use the submit button
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        //[CaptchaValidation("CaptchaCode", "SampleCaptcha", "Incorrect CAPTCHA code!")]
        public ActionResult Login(UserLoginModel model)
        {
            TryUpdateModel(model);
            if (ModelState.IsValid)
            {
                
                var result = repository.GetLoginCredentials(model);

                if (result.UserName != null)
                {
                    Session["LoggedUserId"] = result.Id.ToString();
                    Session["LoggedUserName"] = result.UserName;
                    Session["LoggedUserRole"] = result.Role;
                    return RedirectToAction("AfterLogin");
                }
                else
                {
                    ViewBag.ErrorMessage = "Validation failed!!!";
                }


            }
            else
            {
                ViewBag.ErrorMessage = "Validation failed!!!";
            }

            return View(model);
        }




        public ActionResult AfterLogin()
        {
            if (Session["LoggedUserId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return View("Index");
        }

        public ActionResult AccountEdit()
        {
            return View();
        }

        public ActionResult AanMelden()
        {
            return View();
        }

        public ActionResult LijstMuteren()
        {
            //get fighter list for user id

            List<FighterModel> fighters = new List<FighterModel>();
           
           fighters = repository.GetFightersByUserId(Convert.ToInt32(Session["LoggedUserId"]));

            return View(fighters);
        }


        public ActionResult AddFighter()
        {
           


            return View();
        }

        [HttpPost]
        public ActionResult AddFighter(FighterModel model)
        {
            repository.AddFighter(model);

            return View("LijstMuteren");
        }
    }
}