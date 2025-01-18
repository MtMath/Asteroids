using UnityEngine;

namespace NoTask.Asteroids.Asteroid
{
    [CreateAssetMenu(fileName = "new AsteroidStats", menuName = "Asteroid/Stats", order = 0)]
    public class AsteroidStats : ScriptableObject
    {
        public float minSpeed = 1f;
        public float maxSpeed = 3f;
        public float minSize = 0.5f;
        public float maxSize = 2f;
    }
}