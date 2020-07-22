using UnityEngine;

namespace TDProject
{
    [CreateAssetMenu(fileName = "Enemy", menuName = "Settings/Enemy", order = 1)]
    public class Enemy_SO : ScriptableObject
    {
        public float Speed;
        public float Health;
        public int MoneyCost;
    }
}