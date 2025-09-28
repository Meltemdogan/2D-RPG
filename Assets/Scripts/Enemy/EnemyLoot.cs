using System;
using System.Collections.Generic;
using Inventory;
using UnityEngine;


namespace Enemy
{
    public class EnemyLoot : MonoBehaviour
    {
        [Header("Config")]
        [SerializeField] private float expDrop;
        [SerializeField] private DropItem[] dropItems;
        public float ExpDrop => expDrop;
        public List<DropItem> Items { get; private set; }
        
        private void Start()
        {
            LoadDropItems();
        }
        
        private void LoadDropItems()
        {
            Items = new List<DropItem>();
            foreach (DropItem item in dropItems)
            {
                float prob = UnityEngine.Random.Range(0f, 100f);
                if (prob <= item.DropChance) 
                {
                    Items.Add(item);
                }
            }
        }
    }
    
    [Serializable]
    public class DropItem
    {
        [Header("Config")] 
        public string name;
        public InventoryItem Item;
        public int Quantity;
        
        [Header("Drop Chance")]
        public float DropChance;
        public bool PickedItem { get; set; }
    }
}