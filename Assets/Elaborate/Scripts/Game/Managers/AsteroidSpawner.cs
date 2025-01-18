using NoTask.Asteroids.Asteroid;
using UnityEngine;
using Utils.Patterns;
using Random = UnityEngine.Random;

namespace Game.Managers
{
    public class AsteroidSpawner : Spawner<AsteroidSpawner>
    {
        [Header("Asteroid Settings")]
        [SerializeField] private Asteroid asteroidPrefab;
        [SerializeField] private AsteroidContainer asteroidContainer;
        public float spawnDistance = 12f;
        
        [Range(1, 15)] public int amountPerWave = 1;
        [Range(0f, 45f)] public float variance = 15f;

        public override void Spawn()
        {
            for (var i = 0; i < amountPerWave; i++)
            {
                Vector3 spawnDirection = Random.insideUnitCircle.normalized;
                var spawnPoint = transform.position + (spawnDirection * spawnDistance);

                var range = Random.Range(-variance, variance);
                var rotation = Quaternion.AngleAxis(range, Vector3.forward);

                var asteroid = Instantiate(asteroidPrefab, spawnPoint, rotation);
                asteroid.size = Random.Range(asteroid.stats.minSize, asteroid.stats.maxSize);
                asteroid.transform.SetPositionAndRotation(spawnPoint, rotation);
                asteroid.SetSprite(asteroidContainer.GetRandomSprite());
                
                asteroid.InitializeMovement();
            }
        }
    }
}