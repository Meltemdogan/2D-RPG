using System;
using Extra;
using UnityEngine;


namespace Shop
{
    public class ShopManager : Singleton<ShopManager>
    {
        [Header("Config")]
        [SerializeField] ShopCard shopCardPrefab;
        [SerializeField] Transform shopContainer;
        
        [SerializeField] private ShopItem[] shopItems;
        
        private void Start()
        {
            LoadShop();
        }
        
        private void LoadShop()
        {
            for (int i = 0; i < shopItems.Length; i++)
            {
                ShopCard card = Instantiate(shopCardPrefab, shopContainer);
                card.ConfigShopCard(shopItems[i]);
            }
        }
        
    }
}