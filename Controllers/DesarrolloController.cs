using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using LeonesApi.Models;

namespace LeonesApi.Controllers
{
    public class DesarrolloController : Controller
    {
        public IActionResult Index()
        {
            return View("Folleto");
        }
        public IActionResult Folleto()
        {
            return View();
        }
        public IActionResult Primero()
        {
            return View();
        }
        public IActionResult Segundo()
        {
            return View();
        }
        public IActionResult Tercero()
        {
            return View();
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
