using Microsoft.AspNetCore.Mvc;
using Shop.Management.Models;
using Shop.Management.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Management.Controllers
{
    public class ShopController : Controller
    {
        private ShopService _shopService;
        public ShopController(ShopService shopService)
        {
            _shopService = shopService;
        }
        public IActionResult Index()
        {
            List<ShopItem> _items = _shopService.GetAll();
            return View(_items);
        }
        [HttpGet]
        public IActionResult Add()
        {
            ShopItem item = new ShopItem();
            return View(item);
        }
        [HttpPost]
        public IActionResult Add(ShopItem item)
        {
            _shopService.Add(item);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(string name)
        {
            _shopService.Delete(name);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(string name)
        {
            ShopItem item = _shopService.GetOne(name);
            return View(item);
        }
        [HttpPost]
        public IActionResult Edit(ShopItem item)
        {
            //_shopService.Delete(item.Name);
            //_shopService.Add(item);
            _shopService.Update(item);
            return RedirectToAction("Index");
        }
    }
}
