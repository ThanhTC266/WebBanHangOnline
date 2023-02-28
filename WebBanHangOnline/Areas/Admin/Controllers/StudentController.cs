using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Models;
using WebBanHangOnline.Models.EF;

namespace WebBanHangOnline.Areas.Admin.Controllers
{
    public class StudentController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
        // GET: Admin/Student
        public ActionResult Index()
        {
            //var results = _context.Students.ToList();
            return View();
        }

        public ActionResult GetData()
        {
            var results = _context.Students.ToList();
            return Json(new { Data = results, TotalItems = results.Count }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetById(int id)
        {
            var item = _context.Students.Find(id);
            return Json(new { data = item }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Create(Student model) {
            if(model.Id > 0)
            {
                var item = _context.Students.Find(model.Id);
                item.Name = model.Name;
                item.Age= model.Age;
                item.Class = model.Class;
                _context.Entry(item).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
                return Json(new { success = true });
            }
            model.CreatedDate = DateTime.Now;
            _context.Students.Add(model);
            try
            {
                _context.SaveChanges();
                return Json(new { success = true});
            } catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return Json(new { success = false });
            }
            
            
        }

        [HttpPost]
        public ActionResult Update(Student request)
        {
            var student = _context.Students.Find(request.Id);
            _context.Entry(student).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
            return Json(new { success = false });
        }
    }
}