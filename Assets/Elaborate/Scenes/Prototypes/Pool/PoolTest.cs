using NoTask.Asteroids.Asteroid;
using UnityEngine;
using Utils.Patterns;

public class PoolTest : MonoBehaviour
{
    public AsteroidPool asteroidPool;
    private Asteroid _asteroid;

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.KeypadEnter) && !_asteroid)
        {
            _asteroid = asteroidPool.Get();
            _asteroid.transform.position = Random.insideUnitCircle * 5;
        }

        if (Input.GetKeyDown(KeyCode.Keypad0) && _asteroid)
        {
            asteroidPool.Release(_asteroid);
            _asteroid = null;
        }
    }
}
