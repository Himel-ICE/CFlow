using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebGrease.Css.Ast.Selectors;
using CFlow.Models;

namespace CFlow.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult QuestionPost(FormCollection formCollection, string Post)
        {
            if (Post == "Post")
            {
                if (formCollection["UserQuestion"] == "" || formCollection["QuestionDescription"] == "")
                    return RedirectToAction("Index", "Home");
                string postQuestion = formCollection["UserQuestion"].ToString();
                string postDescription = formCollection["QuestionDescription"].ToString();
                string postTag = formCollection["tag"].ToString();
                int result = Questions.questionPost(postQuestion, postDescription, postTag);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult CommentPost(FormCollection formCollection, string SubComment)
        { 
            if (formCollection["AnsComment"] == "")
                return RedirectToAction("Index", "Home");
            string AnsCommets = formCollection["AnsComment"].ToString();
            int QID = Convert.ToInt32(formCollection["QestionID"].ToString());
            int result = Questions.InsertQuestion(AnsCommets, QID);

            return RedirectToAction("Index", "Home");
        }
    }
}