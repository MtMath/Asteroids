using System;
using UnityEngine;

namespace Scenes.PrototypeScenes.Asteroid
{
    public class AsteroidSplitTest : MonoBehaviour
    {
        [SerializeField] private GameObject asteroidPrefab;
        
        private NoTask.Asteroids.Asteroid.Asteroid _cachedAsteroid;


        private void Awake()
        {
            if (!asteroidPrefab)
            {
                throw new ArgumentNullException(nameof(asteroidPrefab), "Asteroid prefab is not set!");
            }
            
            if(!_cachedAsteroid)
            {
                _cachedAsteroid = FindObjectOfType<NoTask.Asteroids.Asteroid.Asteroid>();
            }
        }

        private void Update()
        {

#if ENABLE_INPUT_SYSTEM
            if (UnityEngine.InputSystem.Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                
                if(_cachedAsteroid.gameObject.activeSelf) _cachedAsteroid.SplitAsteroid();
                else _cachedAsteroid = Instantiate(asteroidPrefab, Vector3.zero, Quaternion.identity).GetComponent<NoTask.Asteroids.Asteroid.Asteroid>();
            }
#else
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _cachedAsteroid.SplitAsteroid();
            }
#endif
            
            
        }
    }
}
