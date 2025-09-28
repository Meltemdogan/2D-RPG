using System;
using Managers;
using UnityEngine;
namespace Enemy
{
    public class EnemySelector : MonoBehaviour
    {
        [Header("Config")]
        [SerializeField] private GameObject selectorSprite;
        private EnemyBrain enemyBrain;
        
        private void Awake()
        {
            enemyBrain = GetComponent<EnemyBrain>();
            if (selectorSprite != null)
            {
                selectorSprite.SetActive(false);
            }
        }
        
        private void OnEnable()
        { 
            SelectionManager.OnEnemySelectedEvent += EnemySelectedCallback;
            SelectionManager.OnNoSelectedEvent += NoSelectionCallback;
        }
        
        
        private void OnDisable()
        {
            SelectionManager.OnEnemySelectedEvent -= EnemySelectedCallback;
            SelectionManager.OnNoSelectedEvent -= NoSelectionCallback;
        }
        
        public void NoSelectionCallback()
        {
            selectorSprite.SetActive(false);
        }
        
        private void EnemySelectedCallback(EnemyBrain enemySelected)
        {
            if (enemySelected == enemyBrain)
            {
                selectorSprite.SetActive(true);
            }
            else
            {
                selectorSprite.SetActive(false);
            }
        }
    }
}