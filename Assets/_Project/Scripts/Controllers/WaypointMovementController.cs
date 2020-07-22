using UnityEngine;

namespace TDProject
{
    public class WaypointMovementController : UpdateBehavior
    {
        [SerializeField] private Enemy_SO enemy;

        private Transform[] waypoints;

        private int currentWaypointIndex = 0;

        public override void DoUpdate()
        {
            // получаем все точки по которым могут перемещаться враги, задаем в самой сцене
            waypoints = WaypointsManager.Instance.Waypoints;

            if (currentWaypointIndex < waypoints.Length)
            {
                // перемещаемся от точки к точке
                transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, Time.deltaTime * enemy.Speed);
                // смотрим в нужную сторону
                transform.LookAt(waypoints[currentWaypointIndex].position);

                // перемещаемся к следующей точке
                if(Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.1f)
                {
                    currentWaypointIndex++;
                }
            }
            else
            {
                //TODO: Pool objs
                ScoreManager.Instance.LoseLife();
                TowerManager.Instance.Enemies.Remove(this.GetComponent<EnemyController>());
                UpdateManager.Instance.UnregisterUpdate(this);
                UpdateManager.Instance.UnregisterUpdate(this.GetComponent<EnemyController>());
                Destroy(gameObject);
            }
        }
    }
}