using MakeMyDish.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MakeMyDish.Controllers
{
    public class CategoryController : Controller
    {
        private readonly MyDBContext myDBContext;
      public  CategoryController()
        {
            myDBContext = new MyDBContext();

        }
        // GET: Category
        public ActionResult Index()
        {
            List<Category> listcategory = new List<Category>();
            listcategory= myDBContext.categories.ToList();

            string msg = Convert.ToString(TempData["message"]);
            string deletemsg = Convert.ToString(TempData["Deletemsg"]);


            ViewBag.updatemessage = msg;
            ViewBag.deletemessage = deletemsg;


            return View(listcategory);
        }

        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (category != null)
            {
                myDBContext.categories.Add(category);
                myDBContext.SaveChanges();
            }


            return RedirectToAction ("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Category category;

            if (id > 0)
            {
                
                category = myDBContext.categories.SingleOrDefault(m => m.id.Equals(id));
            }
            else
            {

                return View("Index");
            }

            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            if (category != null)
            {
                myDBContext.categories.AddOrUpdate(category);
                myDBContext.SaveChanges();
                
            }

            TempData ["message"]="Your Data is Succssefully Updated";
            
            return RedirectToAction("Index");
        }

        
        public ActionResult Delete(int id)
        {
            Category category;
            if (id > 0)
            {
                category= myDBContext.categories.SingleOrDefault(m => m.id.Equals(id));
                myDBContext.categories.Remove(category);
                myDBContext.SaveChanges();
            }

            TempData["Deletemsg"] = "Your Data is Succssefully Deleted";
            return RedirectToAction("Index");

        }

        public ActionResult Details(int id)
        {
            Category category;
            if (id > 0)
            {
                category= myDBContext.categories.SingleOrDefault(m => m.id.Equals(id));
            }
            else
            {
                return View("Index");
            }
            return View(category);
        }

    }
}