using System.Collections;
using Game.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Managers
{
    public class UIManager : MonoBehaviour
    {
        [Header("Canvas")]
        [SerializeField] private Canvas mainMenu;
        [SerializeField] private Canvas hud;
        
        [Header("Buttons")]
        [SerializeField] private Button startButton;
        [SerializeField] private Button highscoreButton;
        
        [Header("Panels")]
        [SerializeField] private GameObject startPanel;
        [SerializeField] private GameObject highscorePanel;
        [SerializeField] private GameObject setScorePanel;
        
        [Header("Views")]
        [SerializeField] private Views.InGameView inGameView;
        [SerializeField] private Views.ScoreboardView scoreboardView;
        
        private void Awake()
        {
            startButton.onClick.AddListener(OnStartButtonClicked);
            highscoreButton.onClick.AddListener(OnHighscoreButtonClicked);
        }

        private void OnHighscoreButtonClicked()
        {
            highscorePanel.SetActive(true);
            startPanel.SetActive(false);
            setScorePanel.SetActive(false);
        }

        private void OnStartButtonClicked()
        {
            mainMenu.gameObject.SetActive(true);
            highscorePanel.SetActive(false);
            setScorePanel.SetActive(false);
            
            StartCoroutine(CoroutineEffects.FadeEffect(mainMenu.GetComponent<CanvasGroup>(), 0f, 1f, () =>
            {
                startPanel.SetActive(false);
                GameManager.Instance.GameStartInvoker();
            }));
        }
        
        public void SetLifeCount(int count)
        {
            inGameView.SetLife(count);
        }
        
        public void ShowMainMenu()
        {
            mainMenu.gameObject.SetActive(true);
            hud.gameObject.SetActive(false);
        }
        
        public void ShowHUD()
        {
            mainMenu.gameObject.SetActive(false);
            hud.gameObject.SetActive(true);
        }
        
        public void SetScore(int score)
        {
            inGameView.SetScore(score);
        }
        
        public void ShowGameOver()
        {
            mainMenu.gameObject.SetActive(true);
            

            StartCoroutine(CoroutineEffects.FadeEffect(mainMenu.GetComponent<CanvasGroup>(), 1f, 0f, () =>
            {
                setScorePanel.SetActive(true);
            }));
        }
    }
}