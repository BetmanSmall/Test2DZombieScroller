using UnityEngine;
using UnityEngine.SceneManagement;
namespace _Game.Scripts.Ui {
    public class GameOverPanel : MonoBehaviour {
        [SerializeField] private GameObject panel;
        
        public static GameOverPanel Instance;

        private void Awake() {
            if (Instance == null) {
                Instance = this;
            }
            Time.timeScale = 1f;
        }

        public void RestartGame() {
            SceneManager.LoadScene(0);
        }

        public void ExitGame() {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
            Application.Quit();
        }

        public void ShowPanel() {
            Time.timeScale = 0f;
            panel.SetActive(true);
            AudioManager.Instance?.PlayRandomGameOver();
        }
    }
}