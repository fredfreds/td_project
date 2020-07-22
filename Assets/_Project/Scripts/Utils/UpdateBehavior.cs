using UnityEngine;

namespace TDProject
{
    public abstract class UpdateBehavior : MonoBehaviour
    {
        // добавляем объект в список апдейта
        public void OnEnable()
        {
            if (UpdateManager.Instance != null)
            {
                UpdateManager.Instance.RegisterUpdate(this);
            }
        }

        // удаляем объект из списка апдейта
        public void OnDisable()
        {
            if (UpdateManager.Instance != null)
            {
                UpdateManager.Instance.UnregisterUpdate(this);
            }
        }

        public abstract void DoUpdate();
    }
}