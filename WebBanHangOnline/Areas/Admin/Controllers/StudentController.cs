﻿using System;
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
            var results = _context.Students.ToList();
            return View(results);
        }

        [HttpPost]
        public ActionResult Create(Student model) {
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
    }
}