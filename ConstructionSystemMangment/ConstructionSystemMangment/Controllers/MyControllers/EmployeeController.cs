using ConstructionSystemMangment.Models;
using ConstructionSystemMangment.Models.Entites;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ConstructionSystemMangment.Controllers.MyControllers
{
    public class EmployeeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
       
        
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult GetEmployees()
        {
            var data = db.Employees.Select(a => new
            {
                Employee = a.EmployeeId,
                a.FirstName,
                a.LastName,
                a.Address,
                a.Image,
                a.Salary,
                a.Gender,
                a.BirthDate,
                a.Phone,
                a.HireDate,
                a.Email,
                Super = a.EmployeeId

            }).ToList();
            //var data = db.Employees.ToList();
            return Json(data, JsonRequestBehavior.AllowGet);

        }
        
        public async Task<JsonResult> CreateEmployee(Employee employee)
        {
            try
            {
                db.Employees.Add(employee);

                var user = new ApplicationUser { UserName = employee.FirstName +" "+employee.LastName , Email = employee.Email , PhoneNumber =employee.Phone
                };
                var result = await UserManager.CreateAsync(user, employee.Password);
                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                }

                db.SaveChanges();
                return Json(new { Add = true, message = " Added Successfuly " }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { Add = false, message = "Error : " + e.InnerException.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult DeleteEmployee(int id)
        {
            try
            {
                var data = db.Employees.Find(id);
                db.Employees.Remove(data);
                db.SaveChanges();
                return Json(new { Delete = true, Message = " Deleted Successfuly ", JsonRequestBehavior.AllowGet });
            }
            catch (Exception e)
            {
                return Json(new { Delete = false, message = "Error : " + e.InnerException.Message }, JsonRequestBehavior.AllowGet);
            }


        }
        public JsonResult EditEmployee(int id)
        {
            var data = db.Employees.Where(b => b.EmployeeId == id).Select(a => new
            {
                Employee = a.EmployeeId,
                a.FirstName,
                a.LastName,
                a.Address,
                a.Image,
                a.Salary,
                a.Gender,
                a.BirthDate,
                a.Phone,
                a.HireDate,
                a.Email,
                Super = a.EmployeeId


            }).FirstOrDefault();
            db.SaveChanges();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult EditEmployee(Employee employee)
        {
            try
            {
                db.Entry(employee).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Json(new { Edit = true, message = "Data Updated Succesfuly" }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception e)
            {
                return Json(new { Edit = false, message = "Data can`t be updated " + e.InnerException.Message }, JsonRequestBehavior.AllowGet);

            }


        }
        
    }
}