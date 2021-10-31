using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using ConsumeThirdPartyApisDemo.Models;
using ConsumeThirdPartyApisDemo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ConsumeThirdPartyApisDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDataService _dataService;

        public HomeController(IDataService dataService)
        {
            _dataService = dataService;
        }
         
        public async Task<IActionResult> Index()
        {
            List<DataModel> dataModels = new List<DataModel>();
            dataModels = await _dataService.GetData();
            return View(dataModels);
        }
    }
}
