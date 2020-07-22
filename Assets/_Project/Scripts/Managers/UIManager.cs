using UnityEngine;
using UnityEngine.UI;

namespace TDProject
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private Button PauseButton;
        [SerializeField] private Button UnpauseButton;
        [SerializeField] private Button ExitButton;

        [SerializeField] private GameObject PausePanel;

        private bool isPaused;

        void OnEnable()
        {
            PauseButton.onClick.AddListener(PauseGame);
            UnpauseButton.onClick.AddListener(PauseGame);
            ExitButton.onClick.AddListener(ExitGame);
        }

        void OnDisable()
        {
            PauseButton.onClick.RemoveListener(PauseGame);
            UnpauseButton.onClick.RemoveListener(PauseGame);
            ExitButton.onClick.RemoveListener(ExitGame);
        }

        void PauseGame()
        {
            isPaused = !isPaused;

            PausePanel.SetActive(isPaused);

            if (isPaused)
                Time.timeScale = 0.0f;
            else
                Time.timeScale = 1.0f;
        }

        void ExitGame()
        {
            Application.Quit();
        }
    }
}