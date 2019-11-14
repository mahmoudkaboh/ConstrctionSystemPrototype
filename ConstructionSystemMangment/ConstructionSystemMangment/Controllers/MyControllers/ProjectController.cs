using ConstructionSystemMangment.Models;
using ConstructionSystemMangment.Models.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConstructionSystemMangment.Controllers.MyControllers
{
    public class ProjectController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Project
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllProject()
        {
            var data = db.Projects.Select(a => new
            {
                a.ProjectId,
                a.Name,
                a.Location,
                a.Image,
                a.Description,
                a.StartDate,
                a.ExpectedPeriod

            }).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult AddProject(Project project)
        {
            try
            {
                db.Projects.Add(project);
                db.SaveChanges();
                return Json(new { Add = true, message = "Added Sucessfuly", JsonRequestBehavior.AllowGet });
            }
            catch (Exception e)
            {
                return Json(new { Add = false, message = " Error " + e.InnerException.Message, JsonRequestBehavior.AllowGet });
            }
        }
        public JsonResult DeleteProject(int id)
        {
            try
            {

                db.Projects.Remove(db.Projects.Find(id));
                db.SaveChanges();
                return Json(new { Delete = true, message = "Deleted Successfuly", JsonRequestBehavior.AllowGet });
            }
            catch (Exception e)
            {
                return Json(new { Delete = false, message = "Error: " + e.InnerException.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpGet]
        public JsonResult EditProject(int id)
        {
            var data = db.Projects.Where(z => z.ProjectId == id).Select(a => new
            {
                a.ProjectId,
                a.Name,
                a.Location,
                a.Image,
                a.Description,
                a.StartDate,
                a.ExpectedPeriod

            }).FirstOrDefault();
            db.SaveChanges();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EditProject(Project project)
        {
            try
            {
                db.Entry(project).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Json(new { Edit = true, message = "Data Updated" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { Edit = false, message = "Data can`t be updated" + e.InnerException.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}