using System;
using System.Collections;
using Game;
using Game.Managers;
using NoTask.Asteroids.Asteroid;
using Patterns;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [Header("Controllers")]
    [SerializeField] private PlayerController playerController;
    [SerializeField] private AsteroidSpawner asteroidSpawner;
    [SerializeField] private HighScoreManager highScoreManager;
    [SerializeField] private UIManager uiManager;
    
    //TODO: Make a VFXManager Later
    [SerializeField] private ParticleSystem explosionEffect;

    //Make an Event Manager Later
    public delegate void GameDelegate();
    public static event GameDelegate OnGameStart;
    public static event GameDelegate OnGameOver;
    public Action<Asteroid> OnAsteroidDestroyed;

    private void OnEnable()
    {
        OnAsteroidDestroyed += AsteroidDestroyed;
        playerController.OnPlayerDeath += OnPlayerDeath;
    }

    private void OnDisable()
    {
        playerController.OnPlayerDeath -= OnPlayerDeath;
    }
    
    private void AsteroidDestroyed(Asteroid asteroid)
    {
        explosionEffect.transform.position = asteroid.transform.position;
        explosionEffect.Play();
        
        //Notify Score
        playerController.Score += asteroid.ScoreValue;
        uiManager.SetScore(playerController.Score);
    }
    
    private void OnPlayerDeath(PlayerController ply)
    {
        explosionEffect.transform.position = playerController.transform.position;
        explosionEffect.Play();
        
        if (playerController.HasLives)
        {
            //TODO: 
            playerController.Lives--;
            uiManager.SetLifeCount(playerController.Lives);
            PlayerRespawn();
        }
        else
        {
            highScoreManager.AddScore(playerController.Score, "MAT");
            GameOverInvoker();
        }
    }
    
    public void PlayerRespawn()
    {
        StartCoroutine(RespawnCoroutine());
    }

    private IEnumerator RespawnCoroutine()
    {
        yield return new WaitForSeconds(3);
        playerController.transform.position = Vector3.zero;
        playerController.gameObject.SetActive(true);
            
        //TODO: Make Blink Effect
    }

    public void GameStartInvoker()
    {
        //TODO:
        playerController.Reset();
        playerController.gameObject.SetActive(true);
        
        asteroidSpawner.Spawn();
        
        OnGameStart?.Invoke();
    }
    public void GameOverInvoker()
    {
        uiManager.ShowGameOver();
        OnGameOver?.Invoke();
    }
}
