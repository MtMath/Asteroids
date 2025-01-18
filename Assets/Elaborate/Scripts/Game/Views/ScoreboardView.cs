using System.Collections.Generic;
using Game.UI;
using UnityEngine;

namespace Game.Views
{
    public class ScoreboardView : MonoBehaviour
    {
        [Header("Scoreboard Components")]
        [SerializeField] private int maxScoreboardItem = 5;
        [SerializeField] private RectTransform scoreboardContent;
        [SerializeField] private ScoreListComponent scoreListPrefab;
        
        private readonly List<ScoreListComponent> _scoreList = new();
        
        private void Awake()
        {
            for (var i = 0; i < maxScoreboardItem; i++)
            {
                var scoreboardItem = Instantiate(scoreListPrefab, scoreboardContent);
                scoreboardItem.SetRank(i + 1);
                scoreboardItem.SetScore(0);
                scoreboardItem.SetName("-");
                
                scoreboardItem.transform.SetSiblingIndex(i + 1);
                _scoreList.Add(scoreboardItem);
            }
        }
        
        public void SetScoreboard(int rank, int score, string username)
        {
            // If the scoreboard is not full, add a new item
            // I Put this sum (1) magic number for practical reasons because the rank starts from 1 in hierarchy 
            if(scoreboardContent.transform.childCount + 1 < maxScoreboardItem && rank < maxScoreboardItem)
            {
                var scoreboardItem = Instantiate(scoreListPrefab, scoreboardContent);
            
                scoreboardItem.SetRank(rank);
                scoreboardItem.SetScore(score);
                scoreboardItem.SetName(username);
            }
            else
            {
                _scoreList[rank].SetRank(rank);
            }
        }
    }
}