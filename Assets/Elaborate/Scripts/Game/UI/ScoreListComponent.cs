using TMPro;
using UnityEngine;

namespace Game.UI
{
    public class ScoreListComponent : MonoBehaviour
    {
        [SerializeField] private TMP_Text rankText;
        [SerializeField] private TMP_Text scoreText;
        [SerializeField] private TMP_Text nameText;
        
        public void SetRank(int rank)
        {
            rankText.SetText(rank.ToString());
        }
        
        public void SetScore(int score)
        {
            scoreText.SetText(score.ToString("N4"));
        }
        
        public void SetName(string username)
        {
            nameText.SetText(username);
        }
    }
}