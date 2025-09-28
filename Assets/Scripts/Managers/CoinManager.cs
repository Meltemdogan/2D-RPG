using System;
using BayatGames.SaveGameFree;
using Extra;
using UnityEngine;


namespace Managers
{
    public class CoinManager : Singleton<CoinManager>
    {
        [SerializeField] private float coinTest;
        public float Coins { get; set; }
        private const string COIN_KEY = "Coins";
        
        private void Start()
        {
            Coins = SaveGame.Load(COIN_KEY, coinTest);
        }
        
        public void AddCoins(float amount)
        {
            Coins += amount;
            SaveGame.Save(COIN_KEY, Coins);
        }
        public void RemoveCoins(float amount)
        {
            Coins -= amount;
            if (Coins >= 0)
            {
                Coins -= amount;
                SaveGame.Save(COIN_KEY, Coins);
            }
        }
    }
}