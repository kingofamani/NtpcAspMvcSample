using s05.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace s05.Controllers
{
    public class SchoolController : Controller
    {
        MvcDBEntities ctx = new MvcDBEntities();
        //05
        // GET: School
        public ActionResult Index()
        {
            List<School> schools = ctx.School.ToList();
            return View(schools);
        }

        //05
        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            School school = ctx.School.Find(id);
            if (school == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound); //HttpNotFound();
            }

            return View(school);
        }

        //06
        public ActionResult Create()
        {
            return View();
        }

        //06
        [HttpPost]
        public ActionResult Create(School school)
        {
            //判斷Model驗證結果
            if (ModelState.IsValid)//若驗證成功，存入DB
            {
                ctx.School.Add(school);
                ctx.SaveChanges();
                return RedirectToAction("Index");//不能用return View("Index");
            }

            return View(school);//若View驗證失敗，顯示之前輸入的結果
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            School school = ctx.School.Find(id);
            if (school == null)
            {
                return HttpNotFound();
            }

            return View(school);
        }

        [HttpPost]
        public ActionResult Edit(School school)
        {
            if (ModelState.IsValid)
            {
                ctx.Entry(school).State = EntityState.Modified;
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(school);
        }

        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }

        //    School school = ctx.School.Find(id);
        //    if (school == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    return View(school);
        //}

        //[HttpPost,ActionName("Delete")]
        //public ActionResult DeleteConfirm(int id)
        //{
        //    School school = ctx.School.Find(id);
        //    ctx.School.Remove(school);
        //    ctx.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //使用confirm確認框
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            School school = ctx.School.Find(id);
            if (school == null)
            {
                return HttpNotFound();
            }

            ctx.School.Remove(school);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}