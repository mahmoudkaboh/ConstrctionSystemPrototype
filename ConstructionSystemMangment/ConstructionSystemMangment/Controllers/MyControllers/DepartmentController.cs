using ConstructionSystemMangment.Models;
using ConstructionSystemMangment.Models.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConstructionSystemMangment.Controllers.MyControllers
{
    public class DepartmentController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Department
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetDepartments()
        {
            var data = db.Departments.Select(a => new
            {
                a.DepartmentID,
                a.Name,
                a.NumberOfEmps
            }).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult AddDepartment(Department department)
        {
            try
            {
                db.Departments.Add(department);
                db.SaveChanges();

                return Json(new { Add = true, message = "added Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { Add = false, message = "Error: " + e.InnerException.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public JsonResult DeleteDepartment(int id)
        {
            try
            {
                var data = db.Departments.Find(id);
                db.Departments.Remove(data);
                db.SaveChanges();
                return Json(new { Delete = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {

                return Json(new { Delete = false, message = "Error: " + e.InnerException.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public JsonResult EditDepartment(int id)
        {
            var data = db.Departments.Where(z => z.DepartmentID == id).Select(a => new {
                a.Name,
                a.NumberOfEmps
            }).FirstOrDefault();
            db.SaveChanges();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult EditDepartment(Department department)
        {
            try
            {
                db.Entry(department).State = System.Data.Entity.EntityState.Modified;
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