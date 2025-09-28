using System;
using Extra;
using UnityEngine;


namespace Enemy.FSM.Actions
{
    public class ActionAttack : FSMAction
    {
        [Header("Config")] [SerializeField] private float damage;
        [SerializeField] private float timeBtwAttack;
        
        private EnemyBrain enemyBrain;
        private float timer;
        private void Awake()
        {
            enemyBrain = GetComponent<EnemyBrain>();
        }
        
        public override void Act()
        {
            AttackPlayer();
        }
        
        private void AttackPlayer()
        {
            if (enemyBrain.Player == null) return;
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                IDamageable player = enemyBrain.Player.GetComponent<IDamageable>();
                player.TakeDamage(damage);
                timer = timeBtwAttack;
            }
        }
    }
}