using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace TDProject
{
    public class SceneManager : Singleton<SceneManager>
    {
        public Button StartGameButton;

        void OnEnable()
        {
            StartGameButton.onClick.AddListener(StartGame);
        }

        void Disable()
        {
            StartGameButton.onClick.RemoveListener(StartGame);
        }

        void StartGame()
        {
            StartCoroutine(LoadYourAsyncScene());
        }

        IEnumerator LoadYourAsyncScene()
        {
            AsyncOperation asyncLoad = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("Level1");

            while (!asyncLoad.isDone)
            {
                yield return null;
            }
        }
    }
}