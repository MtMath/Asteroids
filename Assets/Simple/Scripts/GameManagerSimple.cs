using System.Collections;
using System.Text;
using Game.UI;
using Patterns;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerSimple : Singleton<GameManagerSimple>
{
    [SerializeField] private SpaceShipSimple spaceShip;
    [SerializeField] private ParticleSystem explosionEffect;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private Button newGameButton;
    [SerializeField] private TMP_Text highScoreText;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text livesText;

    public int Score { get; private set; } = 0;
    public int Lives { get; private set; } = 3;
    
    private int _highScore;

    private void Start()
    {
        NewGame();
    }
    
    private void OnEnable()
    {
        newGameButton.onClick.AddListener(NewGame);
    }
    
    private void OnDisable()
    {
        newGameButton.onClick.RemoveListener(NewGame);
    }

    private void NewGame()
    {
        var asteroids = FindObjectsOfType<AsteroidSimple>();

        for (var i = 0; i < asteroids.Length; i++) Destroy(asteroids[i].gameObject);
        gameOverUI.SetActive(false);

        SetScore(0);
        SetLives(3);
        
        StartCoroutine(RespawnCoroutine(spaceShip));
    }

    private void SetScore(int score)
    {
        Score = score;
        scoreText.text = score.ToString("0000");
    }

    private void SetLives(int lives)
    {
        Lives = lives;
        var livesTextBuilder = new StringBuilder();
        for (var i = 0; i < lives; i++) livesTextBuilder.Append($"<sprite name=\"SpaceShip\"> ");
        livesText.SetText(livesTextBuilder.ToString());
    }
    
    public void OnAsteroidDestroyed(AsteroidSimple asteroid)
    {
        explosionEffect.transform.position = asteroid.transform.position;
        explosionEffect.Play();

        if (asteroid.size < 0.7f) SetScore(Score + 100);
        else if (asteroid.size < 1.4f) SetScore(Score + 50);
        else SetScore(Score + 20);
    }

    public void OnPlayerDeath(SpaceShipSimple ship)
    {
        ship.gameObject.SetActive(false);
        
        explosionEffect.transform.position = ship.transform.position;
        explosionEffect.Play();

        SetLives(Lives - 1);

        if (Lives <= 0)
        {
            if(Score > _highScore) _highScore = Score;
            highScoreText.text = _highScore.ToString("0000");
            gameOverUI.SetActive(true);
        }
        else StartCoroutine(RespawnCoroutine(ship));
    }

    private IEnumerator RespawnCoroutine(SpaceShipSimple ship)
    {
        yield return new WaitForSeconds(ship.RespawnDelay);
        spaceShip.transform.position = Vector3.zero;
        spaceShip.gameObject.SetActive(true);
    }
}