using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TDProject
{
    public class TowerManager : Singleton<TowerManager>
    {
        public Tower_SO Tower;
        public List<EnemyController> Enemies = new List<EnemyController>();

        [SerializeField] private Tower_SO SimpleTower;
        [SerializeField] private Tower_SO ComplexTower;

        [SerializeField] private Button SimpleTowerButton;
        [SerializeField] private Button ComplexTowerButton;

        void OnEnable()
        {
            SimpleTowerButton.onClick.AddListener(SelectSimpleTower);
            ComplexTowerButton.onClick.AddListener(SelectComplexTower);
        }

        void Disable()
        {
            SimpleTowerButton.onClick.RemoveListener(SelectSimpleTower);
            ComplexTowerButton.onClick.RemoveListener(SelectComplexTower);
        }

        public void SelectSimpleTower()
        {
            Tower = SimpleTower;
        }

        public void SelectComplexTower()
        {
            Tower = ComplexTower;
        }
    }
}