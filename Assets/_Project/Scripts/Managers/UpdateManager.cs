using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDProject
{
    public class UpdateManager : Singleton<UpdateManager>
    {
        [SerializeField] private List<UpdateBehavior> updateBehaviors = new List<UpdateBehavior>();

        // делаем апдейт всех объектов в одном месте
        void Update()
        {
            for (int i = 0; i < updateBehaviors.Count; i++)
            {
                updateBehaviors[i].DoUpdate();
            }
        }

        public void RegisterUpdate(UpdateBehavior updateBehavior)
        {
            updateBehaviors.Add(updateBehavior);
        }

        public void UnregisterUpdate(UpdateBehavior updateBehavior)
        {
            updateBehaviors.Remove(updateBehavior);
        }
    }
}