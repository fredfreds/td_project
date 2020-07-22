using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDProject
{
    public class BulletController : UpdateBehavior
    {
        public float Speed;
        public float Damage;
        public float Radius;
        public Transform Target;

        public override void DoUpdate()
        {
            if(Target == null)
            {
                Destroy(gameObject);
                return;
            }

            // вычисляем вектор направления по отношению к врагу
            Vector3 direction = Target.position - transform.position;
            float distance = Speed * Time.deltaTime;

            // если длина вектора меньше дельты умноженой на скорость, то попадаем в цель, иначе продолжаем двигаться в ее сторону
            if(direction.magnitude <= distance)
            {
                BulletHit();
            }
            else
            {
                transform.Translate(direction.normalized * distance, Space.World);
                Quaternion rotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * 5);
            }
        }

        void BulletHit()
        {
            if (Radius == 0)
            {
                Target.GetComponent<EnemyController>().TakeDamage(Damage);
            }
            // делаем мега взрыв, который задевает рядом идущих врагов
            else
            {
                Collider[] cols = Physics.OverlapSphere(transform.position, Radius);

                foreach (Collider c in cols)
                {
                    EnemyController e = c.GetComponent<EnemyController>();
                    if(e != null)
                    {
                        e.TakeDamage(Damage);
                    }
                }
            }

            Destroy(gameObject);
        }
    }
}