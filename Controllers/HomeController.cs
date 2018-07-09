using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using quotDojo.Models;


namespace quotDojo.Controllers
{
    
    
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
             List<Dictionary<string, object>> AllQoutes = DbConnector.Query("SELECT * FROM qoute");
            ViewBag.qoutes=AllQoutes;
            
            return View();
        }

        [HttpPost("addQoute")]
        public IActionResult addQoute(string name , string qoute){
            Console.WriteLine(name);
            Console.WriteLine(qoute);
            DateTime d = DateTime.Now;
        try
        {
            string query=$"INSERT INTO qoute (user, qoute,created_at) VALUES ('{name}', '{qoute}','{d}')";
            Console.WriteLine(query);
            DbConnector.Execute(query);
            
        }
        catch 
        {
            Console.WriteLine("Error ");
            return RedirectToAction("Index");
        }


            return RedirectToAction("qoutes");
        }

       [HttpGet("qoutes")]
       public IActionResult Qoutes(){
            
            List<Dictionary<string, object>> AllQoutes = DbConnector.Query("SELECT * FROM qoute");
            ViewBag.qoutes=AllQoutes;
            return View("qoutes");
       }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
