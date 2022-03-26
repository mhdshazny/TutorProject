using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TutorProject.DB;
using TutorProject.Models;

namespace TutorProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext context;

        public HomeController(AppDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            List<StudentModel> data = context.StudentData.ToList();
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(StudentModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.StudentData.Add(model);
                    int result = context.SaveChanges();
                    if (result>0)
                    {
                        return RedirectToAction(nameof(Index),"Home","Success");
                    }
                    else
                    {
                        return RedirectToAction(nameof(Create),"Home","UploadError");
                    }
                }
                else
                {
                    return RedirectToAction(nameof(Create),Response.StatusCode);
                }
            }
            catch (Exception er)
            {
                return RedirectToAction(nameof(Create),"Home",er.Message);
            }
        }
    }
}
