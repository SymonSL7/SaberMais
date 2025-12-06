using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SaberMais.Models;

namespace SaberMais.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        if (!User.Identity.IsAuthenticated)
        {
            return View();
        }
        else
        {
            return RedirectToAction("Index", "Cursos");
        }
        
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error(int? statusCode = null)
    {
        if (statusCode.HasValue)
        {
            if (statusCode == 404)
            {
                ViewBag.TituloErro = "Página não encontrada";
                ViewBag.MensagemErro = "O usuário ou o recurso que você procurava não existe ou foi movido.";
                return View("NotFound"); 
            }
            
            
        }

        
        ViewBag.TituloErro = "Ocorreu um erro";
        ViewBag.MensagemErro = "Algo deu errado. Tente novamente mais tarde.";
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
