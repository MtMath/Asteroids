using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Managers
{
    public class HighScoreManager : MonoBehaviour
    {
        public const int MaxHighScores = 5;
        
        /// <summary>
        /// Simulates a database of high scores
        /// </summary>
        public Dictionary<string, int> HighScores { get; private set; } = new(MaxHighScores);
        
        public void AddScore(int newScore, string playerName)
        {
            if (HighScores.ContainsKey(playerName))
            {
                if (newScore > HighScores[playerName])
                {
                    HighScores.TryAdd(playerName, newScore);
                }
            }
            else
            {
                HighScores[playerName] = newScore;
            }

            HighScores = HighScores
                .OrderByDescending(entry => entry.Value)
                .Take(MaxHighScores)
                .ToDictionary(entry => entry.Key, entry => entry.Value);
        }
    }
}