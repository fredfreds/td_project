using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace TDProject
{
    public class WavesManager : UpdateBehavior
    {
        public float TimeBetweenWaves = 10f;

        [SerializeField] private Wave_SO wave;
        [SerializeField] private Text waveInfo;

        private int enemyCount = 0;
        private float countdown = 2f;
        private int waveIndex = 0;

        void Start()
        {
            //InvokeRepeating("SpawnEnemy", wave.StartSpawnTime, wave.TimeBetweenEnemySpawn);
        }

        void SpawnEnemy()
        {
            //enemyCount++;
            GameObject enemy = Instantiate(wave.EnemyPrefab, wave.SpawnPoint, Quaternion.identity);

            // добавляем врага в список, чтоб его могли определять турели
            TowerManager.Instance.Enemies.Add(enemy.GetComponent<EnemyController>());
        }

        public override void DoUpdate()
        {
            //if (enemyCount == wave.SizeOfTheWave)
            //{
            //    CancelInvoke("SpawnEnemy");
            //}

            if(countdown <= 0f)
            {
                StartCoroutine(SpawnWave());
                countdown = TimeBetweenWaves;
            }

            countdown -= Time.deltaTime;

            waveInfo.text = "Next Wave in: " + Mathf.Floor(countdown).ToString();
        }

        IEnumerator SpawnWave()
        {
            waveIndex++;

            for (int i = 0; i < waveIndex; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(0.5f);
            }
        }
    }
}