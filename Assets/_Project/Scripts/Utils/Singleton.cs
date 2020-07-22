using UnityEngine;

namespace TDProject
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T instance;
        public static T Instance
        {
            get
            {
                if (instance == null)
                    instance = FindObjectOfType<T>();
                return instance;
            }
        }

        protected void Awake()
        {
            if (instance == null)
                instance = this as T;
            else if (instance != this)
                DestroySelf();
        }

        // убедимся что есть только один инстанс объекта
        protected void OnValidate()
        {
            if (instance == null)
                instance = this as T;
            else if (instance != this)
            {
                Debug.LogError("Singleton<" + this.GetType() + "> already has an instance on scene. Component will be destroyed.");
#if UNITY_EDITOR
                UnityEditor.EditorApplication.delayCall -= DestroySelf;
                UnityEditor.EditorApplication.delayCall += DestroySelf;
#endif
            }
        }


        private void DestroySelf()
        {
            if (Application.isPlaying)
                Destroy(this);
            else
                DestroyImmediate(this);
        }
    }
}