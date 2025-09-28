using System;
using Inventory;
using UnityEngine;


namespace Players
{
    
}
public class Player : MonoBehaviour
{
    [Header("Config")] 
    [SerializeField] private PlayerStats stats;
    
    [Header("Test")]
    public ItemHealthPotion HealthPotion;
    public ItemManaPotion ManaPotion;
    
    
    public PlayerMana PlayerMana { get; private set; }
    public PlayerHealth PlayerHealth { get; private set; }
    public PlayerAttack PlayerAttack{ get; set; }
    public PlayerStats Stats => stats;
    
    private void Awake()
    {
        PlayerMana = GetComponent<PlayerMana>();
        PlayerHealth = GetComponent<PlayerHealth>();
        PlayerAttack = GetComponent<PlayerAttack>();
        animations = GetComponent<PlayerAnimations>();
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            HealthPotion.UseItem();
            if (HealthPotion.UseItem())
            {
                Debug.Log("Health Potion Used");
            }
            if (ManaPotion.UseItem())
            {
                Debug.Log("Mana Potion Used");
            }
        }
        
    }
    
    private PlayerAnimations animations;
    
    public void ResetPlayer()
    {
        stats.ResetPlayer();
        animations.ResetPlayer();
        PlayerMana.ResetMana();
    }
}