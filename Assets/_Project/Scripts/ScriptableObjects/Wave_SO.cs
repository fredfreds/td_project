using UnityEngine;

namespace TDProject
{
    [CreateAssetMenu(fileName = "Wave", menuName = "Settings/Wave", order = 1)]
    public class Wave_SO : ScriptableObject
    {
        public int SizeOfTheWave;
        public float TimeBetweenEnemySpawn;
        public float StartSpawnTime;

        public GameObject EnemyPrefab;

        public Vector3 SpawnPoint;
    }
}