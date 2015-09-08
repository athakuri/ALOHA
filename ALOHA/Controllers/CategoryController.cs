using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ALOHA.Models;

namespace ALOHA.Controllers
{
    public class CategoryController : Controller
    {
        //
        // GET: /Category/

        //public ActionResult Index()
        //{
        //    return View();
        //}

        CategoryModel categorymodels = new CategoryModel();
        [HttpGet]

        public ActionResult Add()
        {
            Category model = new Category();
            return View(model);
        }
        1
        [HttpPost]
        public ActionResult Add(Category category)
        {
            if (ModelState.IsValid) //checking model is valid or not
            {
                bool result = categorymodels.Add(category);
                if (result)
                {
                    List<Category> model = new List<Category>();
                    model = categorymodels.SelectAll();
                    return View("List", model);
                }
            }

            return View(category);
        }

        [HttpGet]
        public ActionResult List()
        {
            List<Category> model = new List<Category>();
            model = categorymodels.SelectAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int Id = 0)
        {
            Category category = new Category();
            category = categorymodels.SelectById(Id);
            return View("Edit", category);
        }
        
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid) //checking model is valid or not
            {
                categorymodels.Edit(category);
                List<Category> model = new List<Category>();
                model = categorymodels.SelectAll();
                return View("List", model);
            }
            return View(category);
        }

        [HttpGet]
        public ActionResult Delete(int Id = 0)
        {
            categorymodels.Delete(Id);
            List<Category> model = new List<Category>();
            model = categorymodels.SelectAll();
            return View("List", model);
        }


    }
}
}
