using System;
using Extra;
using Managers;
using UnityEngine;


    public class PlayerHealth : MonoBehaviour , IDamageable
    {
        [Header("Config")] 
        [SerializeField] private PlayerStats stats;
        
        private PlayerAnimations playerAnimations;
        
        private void Awake()
        {
            playerAnimations = GetComponent<PlayerAnimations>();
        }
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                TakeDamage(1f);
            }
        }
        
        public void TakeDamage(float amount)
        {
            if (stats.Health <= 0) return;
            stats.Health -= amount;
            DamageManager.Instance.ShowDamageText(amount, transform);
            if (stats.Health <= 0)
            {
                stats.Health = 0;
                PlayerDeath();
            }
        }
        
        public void RestoreHealth(float amount)
        {
            stats.Health += amount;
            if (stats.Health > stats.MaxHealth)
            {
                stats.Health = stats.MaxHealth;
            }
        }
        
        public bool CanRestoreHealth()
        {
            return stats.Health > 0 && stats.Health < stats.MaxHealth;
        }
        
        private void PlayerDeath()
        {
            playerAnimations.ShowDeathAnimation();
        }
    }
