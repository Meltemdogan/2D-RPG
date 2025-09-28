using System;
using Extra;
using UnityEngine;
namespace Weapons
{
    public class Projectile : MonoBehaviour
    {
        [Header("Config")]
        [SerializeField] private float speed = 10f;
        public Vector3 Direction { get; set; }
        public float Damage { get; set; }
        
        private void Update()
        {
            transform.Translate(Direction * speed * Time.deltaTime);
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            other.GetComponent<IDamageable>()?.TakeDamage(Damage);
            Destroy(gameObject);
        }
    }
}