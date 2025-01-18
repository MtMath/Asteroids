using TMPro;
using UnityEngine;

namespace Game.Views
{
    public class InGameView : MonoBehaviour
    {
        [Header("Score Components")]
        [SerializeField] private TMP_Text scoreText;
        
        [Header("Life Components")]
        [SerializeField] private GameObject lifeImagePrefab;
        [SerializeField] private RectTransform lifeContent;
        
        public void SetScore(int score)
        {
            scoreText.SetText(score.ToString("0000"));
        }
        
        public void SetLife(int life)
        {
            var lifeCount = lifeContent.transform.childCount;

            if (lifeCount < life)
            {
                Instantiate(lifeImagePrefab, lifeContent);
            }
            else
            {
                for (var i = 0; i < lifeCount; i++)
                {
                    lifeContent.transform.GetChild(i).gameObject.SetActive(i < life);
                }
            }
        }
        
        public void SetGameOver()
        {
            
        }

        public void ResetView()
        {
            SetScore(0);
            SetLife(3);
        }
        
    }
}