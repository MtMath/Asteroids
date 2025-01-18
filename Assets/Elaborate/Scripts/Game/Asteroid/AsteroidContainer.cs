using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace NoTask.Asteroids.Asteroid
{
    /// <summary>
    /// TODO: Use later
    /// </summary>
    public enum AsteroidSize : byte
    {
        Small = 0,
        Medium = 1,
        Large = 2
    }
    
    /// <summary>
    /// TODO: Use later
    /// </summary>
    [Serializable]
    public struct AsteroidData
    {
        public AsteroidStats stats;
        public AsteroidSize size;
        public int splitCount;
        public int score;
    }
    
    [CreateAssetMenu(fileName = "new AsteroidContainer", menuName = "Asteroid/Container", order = 0)]
    public sealed class AsteroidContainer : ScriptableObject
    {
        public Sprite[] asteroidSprites;
        public AsteroidData[] asteroidData;
        
        private AsteroidData GetAsteroidData(AsteroidSize size)
        {
            foreach (var data in asteroidData)
            {
                if (data.size == size) return data;
            }

            return default;
        }
        
        public AsteroidStats GetAsteroidStats(AsteroidSize size)
        {
            return GetAsteroidData(size).stats;
        }
        
        public Sprite GetRandomSprite()
        {
            return asteroidSprites[Random.Range(0, asteroidSprites.Length)];
        }
        
        public int GetAsteroidSplitCount(AsteroidSize size)
        {
            return GetAsteroidData(size).splitCount;
        }
        
        public int GetAsteroidScore(AsteroidSize size)
        {
            return GetAsteroidData(size).score;
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (asteroidData.Length != Enum.GetValues(typeof(AsteroidSize)).Length)
            {
                Debug.LogError("AsteroidData array must have same size of AsteroidSize elements");
                asteroidData[^1] = default;
            }
        }
#endif
    }
}