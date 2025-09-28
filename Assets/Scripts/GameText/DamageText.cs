using TMPro;
using UnityEngine;


namespace GameText
{
    public class DamageText : MonoBehaviour
    {
        [Header("Config")]
        [SerializeField] private TextMeshProUGUI damageTMP;
        
        public void SetDamageText(float damage, Transform parent)
        {
            damageTMP.text = damage.ToString();
            transform.SetParent(parent);
        }
        
        public void DestroyText()
        {
            Destroy(gameObject);
        }
    }
}