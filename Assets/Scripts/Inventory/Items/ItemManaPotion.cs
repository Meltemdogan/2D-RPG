using Managers;
using UnityEngine;
namespace Inventory
{
    [CreateAssetMenu(fileName = "ItemManaPotion", menuName = "Items/Mana Potion")]
    public class ItemManaPotion : InventoryItem
    {
        [Header("Config")]
        public float ManaValue;
        
        public override bool UseItem()
        {
            if (GameManager.Instance.Player.PlayerMana.CanRecoverMana())
            {
                GameManager.Instance.Player.PlayerMana.RecoverMana(ManaValue);
                return true;
            }
            return false;
        }
    }
}