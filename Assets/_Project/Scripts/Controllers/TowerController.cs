using UnityEngine;

namespace TDProject
{
    public class TowerController : UpdateBehavior
    {
        public bool CanPlace = true;

        private Tower_SO tower;
        private Transform currentTower;

        private float fireCooldownLeft;

        public override void DoUpdate()
        {
            if (currentTower == null)
            {
                return;
            }

            EnemyController enemy = null;
            float distance = Mathf.Infinity;

            // вычисляем ближайшего врага 
            foreach(EnemyController e in TowerManager.Instance.Enemies)
            {
                float d = Vector3.Distance(transform.position, e.transform.position);
                if(enemy == null || d < distance)
                {
                    enemy = e;
                    distance = d;
                }
            }

            if(enemy == null)
            {
                return;
            }

            // находим направление к ближайшему врагу
            Vector3 dir = enemy.transform.position - transform.position;
            // считаем поворот
            Quaternion look = Quaternion.LookRotation(dir);
            // устанавливаем поворот турели по одной оси
            currentTower.rotation = Quaternion.Euler(0, look.eulerAngles.y, 0);
            // считаем время следующего выстрела в зависимости от задержки
            fireCooldownLeft -= Time.deltaTime;
            if(fireCooldownLeft <= 0 && dir.magnitude <= tower.Range)
            {
                fireCooldownLeft = tower.FireCooldown;
                ShootAt(enemy);
            }
        }

        // размещяем тавер в нужном нам месте, с помощью рейкаста
        public void PlaceTower(Vector3 pos)
        {
            tower = TowerManager.Instance.Tower;

            // проверяем хватает ли нам денег
            if (ScoreManager.Instance.Money < tower.Cost)
            {
                return;
            }
            // отнимаем стоимость тавера
            ScoreManager.Instance.Money -= tower.Cost;
            ScoreManager.Instance.SetScore();
            currentTower = Instantiate(tower.Prefab, transform.position + tower.Offset, Quaternion.identity).transform;
            currentTower.parent = transform;
        }

        // стреляем по врагу
        void ShootAt(EnemyController e)
        {
            GameObject bullet = Instantiate(tower.Bullet.gameObject, transform.position, transform.rotation);

            BulletController b = bullet.GetComponent<BulletController>();
            b.Speed = tower.BulletSpeed;
            b.Damage = tower.Damage;
            b.Radius = tower.Radius;
            b.Target = e.transform;
        }
    }
}