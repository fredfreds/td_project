using UnityEngine;
using UnityEngine.UI;

namespace TDProject
{
    public class ScoreManager : Singleton<ScoreManager>
    {
        public int Money { get; set; } = 10;

        [SerializeField] private Text ScoreText;
        [SerializeField] private Text MoneyText;

        [SerializeField] private int Lifes = 10;

        public void LoseLife(int life = 1)
        {
            SetScore();

            Lifes -= life;
            if(Lifes <= 0)
            {
                GameOver();
            }
        }

        public void SetScore()
        {
            MoneyText.text = "Money: " + Money.ToString();
            ScoreText.text = "Score: " + Lifes.ToString();
        }

        // по завершении игры перезагружаем сцену
        void GameOver()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }
    }
}