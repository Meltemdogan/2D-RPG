using System;


namespace Inventory
{
    [Serializable]
    public class InventoryData
    {
        public string[] ItemContent; //Store the item IDs
        public int[] ItemQuantity; //Store the quantity of each item
    }
}