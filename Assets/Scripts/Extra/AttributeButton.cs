using System;
using UnityEngine;

namespace Extra
{
    public class AttributeButton : MonoBehaviour
    {
        public static event Action<AttributeType> OnAttributeSelectedEvent;
        
        [Header("Config")]
        [SerializeField] private AttributeType attributeType;
        
        public void SelectAttribute()
        {
            OnAttributeSelectedEvent?.Invoke(attributeType);
        }
        
    }
}