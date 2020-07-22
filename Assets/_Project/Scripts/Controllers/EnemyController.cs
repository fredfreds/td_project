using UnityEngine;

namespace TDProject
{
    public class EnemyController : UpdateBehavior
    {
        [SerializeField] private Enemy_SO enemy;

        private float health;

        public override void DoUpdate()
        {

        }

        // считаем урон по врагу от снаряда
        public void TakeDamage(float damage)
        {
            health -= damage;
            
            if(health <= 0)
            {
                Die();
            }
        }

        void Start()
        {
            health = enemy.Health;
            ScoreManager.Instance.SetScore();
        }

        // в случае смерти пополняем кредиты для покупки таверов
        void Die()
        {
            ScoreManager.Instance.Money += enemy.MoneyCost;
            ScoreManager.Instance.SetScore();
            TowerManager.Instance.Enemies.Remove(this);
            UpdateManager.Instance.UnregisterUpdate(this);
            UpdateManager.Instance.UnregisterUpdate(this.GetComponent<WaypointMovementController>());
            Destroy(gameObject);
        }
    }
}