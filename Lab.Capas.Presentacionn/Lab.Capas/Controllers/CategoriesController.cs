using Lab.Capas.Models;
using Lab.Demo.Entities;
using Lab.Demo.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab.Capas.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories
        public ActionResult Index()
        {
            var logic = new CategoriesLogic();
            var categories = logic.GetAll();
            List < CategoriesView > categoriesViews = (from category in categories
                                                       select new CategoriesView() { CategoryId = category.CategoryID,
                                                       CategoryName = category.CategoryName,
                                                       Description = category.Description}).ToList();
            return View(categoriesViews);
        }
        [HttpGet]
        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(Categories category)
        {
            var logic = new CategoriesLogic();
            var categoryEntity = new Categories() { CategoryName = category.CategoryName, Description = category.Description };
            if (ModelState.IsValid)
            {
                logic.Insert(categoryEntity);
                return RedirectToAction("index");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit (int id)
        {
            CategoriesLogic logic = new CategoriesLogic();
            Categories categories = logic.GetOne(id);
            return View(categories);
        }

        [HttpPost]
        public ActionResult Edit (Categories categories)
        {
            var logic = new CategoriesLogic();
            if (ModelState.IsValid)
            {
                logic.Update(categories);
                return RedirectToAction("index");
            } else
            {
                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            try
            {
                var logic = new CategoriesLogic();
                logic.Delete(id);

            }
            catch (Exception)
            {
                throw new Exception("Ocurrio un problema"); 
            }
        
            return RedirectToAction("index");
        }


    }
}