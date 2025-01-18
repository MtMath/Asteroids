using Managers;
using UnityEngine;
using NoTask.Asteroids.Ship;
using NoTask.Asteroids.Input;

namespace Game
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] private InputHandler inputHandler;
        [SerializeField] private SpaceShip spaceShip;

        public int Lives { get; set; } = 3;
        public int Score { get; set; } = 0;
        public bool HasLives => Lives > 0;

        public event System.Action<PlayerController> OnPlayerDeath;

        private void Update()
        {
            if (inputHandler.CurrentInputPayload.IsFiring) spaceShip.Shoot();
        }

        private void FixedUpdate()
        {
            HandleScreenWrapping();

            spaceShip.Move(inputHandler.CurrentInputPayload.InputVector);
            spaceShip.Rotate(inputHandler.CurrentInputPayload.InputVector);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.gameObject.CompareTag("Asteroid")) return;

            spaceShip.Rigidbody.velocity = Vector3.zero;
            spaceShip.Rigidbody.angularVelocity = 0f;
            spaceShip.gameObject.SetActive(false);

            OnPlayerDeath?.Invoke(this);
        }

        private void HandleScreenWrapping()
        {
            var currentPosition = spaceShip.Rigidbody.position;
            var wrappedPosition = ScreenWrapping.Instance.GetWrappedPosition(currentPosition);
            spaceShip.Rigidbody.position = wrappedPosition;
        }

        public void Reset()
        {
            Score = 0;
            Lives = 3;
        }
    }
}