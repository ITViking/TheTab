using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Stregelisten.Data;
using Stregelisten.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore.Internal;
using System.Threading.Tasks;
using Stregelisten.Models.BarViewModels;
using System;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Stregelisten.Controllers
{

    [Authorize]
    public class BarController : Controller
    {       
        private ApplicationDbContext _context;        
        
        public BarController(ApplicationDbContext context)
        {
            _context = context;
        }        


        [HttpGet]
        public IActionResult Index()
        {
            return View(_context.Beverages.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> Index(string items)
        {
            string bevs = items;
            
            List<Beverage> boughtBeverages = JsonConvert.DeserializeObject<List<Beverage>>(bevs);

            ClaimsPrincipal currentUser = this.User;
            var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;

            if (0 < boughtBeverages.Count)
            {
                DateTime dateTime = new DateTime();
                using (var context = _context)
                {
                    List<Procurement> procList = new List<Procurement>();
                    foreach (var item in boughtBeverages)
                    {
                        Procurement procurement = new Procurement();
                        procurement.BeverageId = item.Id;
                        procurement.Price = item.Price;
                        procList.Add(procurement);
                    }

                    var list = new List<Procurement>();

                    var tab = new Tab()
                    {
                        UserId = currentUserID,

                        Procurements = procList,

                        IsPaid = false,

                        DateTime = DateTime.Now
                    };

                    _context.Add(tab);
                    await _context.SaveChangesAsync();

                    int tabId = tab.Id;

                    return Json(new { redirectToUrl = Url.Action("Tab", "Bar", new { id = tabId }) });
                }
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Tab(int id)
        {
            ClaimsPrincipal currentUser = this.User;
            var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;

            if (id ==  _context.Tabs.Where(x => x.UserId == currentUserID).Where(t => t.Id == id).First().Id)
            {
                var boughtBeverages = from procurement in _context.Procurements
                                      join beverage in _context.Beverages
                                      on procurement.BeverageId equals beverage.Id
                                      where procurement.TabId == id
                                      select beverage;

                List<Beverage> beverages = new List<Beverage>();

                foreach (var item in boughtBeverages)
                {
                    beverages.Add(item);
                }

                return View(beverages);
            }
            else
            {
                return NotFound(id);
            }            
        }

        [HttpGet]
        public IActionResult Tabs()
        {
            ClaimsPrincipal currentUser = this.User;
            var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            List<TabViewModel> tabViewModelList = new List<TabViewModel>();

            var UsersTabs = _context.Tabs.Where(x => x.UserId == currentUserID);
            var tabsProcurements = from procurements in _context.Procurements
                                   group procurements by procurements.TabId into procsTab
                                   select new
                                   {
                                       procTabId = procsTab.First().TabId,
                                       procsPrice = procsTab.Sum(x => x.Price)
                                   };
                                   


            foreach (var item in UsersTabs)
            {
                TabViewModel tabViewModel = new TabViewModel();

                tabViewModel.Id = item.Id;
                tabViewModel.IsPaid = item.IsPaid;
                tabViewModel.UserId = item.UserId;
                tabViewModel.DateTime = item.DateTime;
                tabViewModel.Price = tabsProcurements.Where(x => x.procTabId == item.Id).Select(x => x.procsPrice).First();

                tabViewModelList.Add(tabViewModel);
            }
            

            return View(tabViewModelList);
        }
    }
}
