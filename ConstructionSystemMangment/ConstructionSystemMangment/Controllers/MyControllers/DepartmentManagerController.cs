using ConstructionSystemMangment.Models;
using ConstructionSystemMangment.Models.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConstructionSystemMangment.Controllers.MyControllers
{
    public class DepartmentManagerController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: DepartmentManager
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetDepartmentManager()
        {
            var data = db.DepartmentManagers.Select(a => new
            {
                a.MangerId,
                a.FirstName,
                a.LastName,
                a.DepartmentID,
                a.EmployeeId,
                a.StartDate
            }).ToList();
            return Json(data,JsonRequestBehavior.AllowGet);
        }
        public JsonResult AddDepartmentManager(DepartmentManager departmentManager)
        {
            try
            {
                db.DepartmentManagers.Add(departmentManager);
                db.SaveChanges();
                return Json(new {Add = true , message ="Added Sucessfuly",JsonRequestBehavior.AllowGet });
            }
            catch(Exception e )
            {
                return Json(new { Add = false, message = " Error " + e.InnerException.Message, JsonRequestBehavior.AllowGet });
            }
        }
        public JsonResult DeleteDepartmentManager(int id)
        {
            try
            {
                
                db.DepartmentManagers.Remove(db.DepartmentManagers.Find(id));
                db.SaveChanges();
                return Json(new { Delete = true, message = "Deleted Successfuly", JsonRequestBehavior.AllowGet });
            }
            catch(Exception e)
            {
                return Json(new { Delete = false, message = "Error: " + e.InnerException.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpGet]
        public JsonResult EditDepartmentManager(int id)
        {
            var data = db.DepartmentManagers.Where(z => z.MangerId == id).Select(a => new
            {
                a.MangerId,
                a.FirstName,
                a.LastName,
                a.DepartmentID,
                a.EmployeeId,
                a.StartDate

            }).FirstOrDefault();
            db.SaveChanges();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EditDepartmentManager(DepartmentManager departmentManager)
        {
            try
            {
                db.Entry(departmentManager).State = System.Data.Entity.EntityState.Modified;
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