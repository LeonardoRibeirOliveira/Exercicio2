using Exercicio2.Models;
using Exercicio2.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Exercicio2.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDataService _dataService;

        public HomeController(IDataService dataService)
        {
            _dataService = dataService;
        }

        public async Task<ActionResult<IEnumerable<Data>>> Index()
        {
            var resultado = await _dataService.GetAll();
            if(resultado != null)
            {
                return View(resultado);
            }
            else
            {
                return View();
            }
        }
    }
}