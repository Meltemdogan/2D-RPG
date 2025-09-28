using System;
using Inventory;


namespace Shop
{
    [Serializable]
    public class ShopItem
    {
        public string Name;
        public InventoryItem Item;
        public float Cost;
        
    }
}