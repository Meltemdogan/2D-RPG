using Managers;
using UnityEngine;
using Weapons;


namespace Inventory
{
    [CreateAssetMenu(fileName = "ItemWeapon", menuName = "Items/Weapon")]
    public class ItemWeapon : InventoryItem
    {
        [Header("Weapon")] 
        
        public Weapon Weapon;
        
        public override void EquipItem()
        {
           WeaponManager.Instance.EquipWeapon(Weapon);
        }
    }
}