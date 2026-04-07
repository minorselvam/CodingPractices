using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderPlacementSystem
{
    public class InventoryService
    {
        private Dictionary<string, int> inventory = new Dictionary<string, int>();

        //Initialize inventory with some products
        public InventoryService()
        {
            inventory["Laptop"] = 10;
            inventory["Head Phone"] = 32;
            inventory["Data Cable Set"] = 6;
        }

        //Check stock
        public bool CheckStock(string productName, int Quantity)
        {
            return inventory.ContainsKey(productName) && inventory[productName] >= Quantity;
        }

        //Deduct Stock
        public void DeductStock(string productName, int Quantity)
        {
            if(CheckStock(productName, Quantity))
            {
                inventory[productName] = inventory[productName] - Quantity;
            }
        }
    }
}
