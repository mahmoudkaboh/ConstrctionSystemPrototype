using ConstructionSystemMangment.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConstructionSystemMangment.Controllers
{
    [Authorize(Roles ="Admin")]
    public class RoleController : Controller
    {
        ApplicationDbContext context;
         
        public RoleController()
        {
            context = new ApplicationDbContext();
        }

        /// <summary>
        /// GET ALL ROLES
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var Roles = context.Roles.ToList();
            return View(Roles);
        }

        //Create A New Role 
        public ActionResult Create()
        {
            var Role = new IdentityRole();
            return View();
        }


        [HttpPost]
        public ActionResult Create(IdentityRole Role)
        {
            context.Roles.Add(Role);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }



    }
}