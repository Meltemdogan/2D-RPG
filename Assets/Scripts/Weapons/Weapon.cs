using UnityEngine;
namespace Weapons
{
    public enum WeaponType
    {
        Magic,
        Melee
    }
    
    [CreateAssetMenu(fileName = "NewWeapon", menuName = "Weapons/Weapon")]
    public class Weapon : ScriptableObject
    {
        [Header("Config")]
        public Sprite Icon;
        public WeaponType WeaponType;
        public float Damage;
        
        [Header("Projectile")] 
        public Projectile ProjectilePrefab;
        public float RequiredMana;
    }
}