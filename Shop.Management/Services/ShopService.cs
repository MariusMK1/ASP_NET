using Shop.Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Management.Services
{
    public class ShopService
    {
        private List<ShopItem> _shopItems;
        public ShopService()
        {
            _shopItems = new List<ShopItem>();
        }

        public List<ShopItem> GetAll()
        {
            return _shopItems;
        }
        public void Add(ShopItem item)
        {
            _shopItems.Add(item);
        }
        public void Delete(string name)
        {
            _shopItems = _shopItems.Where(x => x.Name != name).ToList();
        }
        public ShopItem Edit(string name)
        {
            ShopItem shopItem = _shopItems.Where(x => x.Name == name).FirstOrDefault();
            return shopItem;
        }
    }
}
