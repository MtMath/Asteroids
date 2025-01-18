using UnityEngine;

public class SpawnerSimple : MonoBehaviour
{
    public AsteroidSimple asteroidPrefab;
    public float spawnDistance = 12f;
    public float spawnRate = 1f;
    public int amountPerSpawn = 1;
    
    [Range(0f, 45f)]
    public float trajectoryVariance = 15f;

    private void Start()
    {
        InvokeRepeating(nameof(Spawn), spawnRate / 2, spawnRate);
    }

    public void Spawn()
    {
        for (var i = 0; i < amountPerSpawn; i++)
        {
            Vector3 spawnDirection = Random.insideUnitCircle.normalized;
            var spawnPoint = transform.position + (spawnDirection * spawnDistance);

            var variance = Random.Range(-trajectoryVariance, trajectoryVariance);
            var rotation = Quaternion.AngleAxis(variance, Vector3.forward);

            var asteroid = Instantiate(asteroidPrefab, spawnPoint, rotation);
            asteroid.size = Random.Range(asteroid.minSize, asteroid.maxSize);

            Vector2 trajectory = rotation * -spawnDirection;
            asteroid.SetTrajectory(trajectory);
        }
    }
}
