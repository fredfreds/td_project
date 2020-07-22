using UnityEngine;

namespace TDProject
{
    [CreateAssetMenu(fileName = "Tower", menuName = "Settings/Tower", order = 1)]
    public class Tower_SO : ScriptableObject
    {
        public GameObject Prefab;

        public BulletController Bullet;

        public float FireCooldown;
        public float BulletSpeed;
        public float Damage;
        public float Range;
        public float Radius;
        public int Cost;

        public Vector3 Offset;
    }
}