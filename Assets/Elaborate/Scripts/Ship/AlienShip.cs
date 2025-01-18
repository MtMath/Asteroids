using Managers;
using UnityEngine;

namespace NoTask.Asteroids.Ship
{
    public class AlienShip : Ship
    {
        private Vector2 _movementDirection;
        
        private void InitializeMovement()
        {
            _movementDirection = new Vector2(
                Random.Range(-1f, 1f), 
                Random.Range(-1f, 1f)
            ).normalized;
        }
        
        private void Start()
        {
            InitializeMovement();
        }
        private void FixedUpdate()
        {
            HandleScreenWrapping();
            Move(_movementDirection);

            if (Time.frameCount % Random.Range(50, 150) != 0) return;
            if (ScreenWrapping.Instance.IsOutOfBounds(_rigidbody2D.position)) return;
            
            Shoot();
        }
        
        public override void Shoot()
        {
            Debug.Log("Pew!");
        }

        public override void Move(Vector2 direction)
        {
            _rigidbody2D.velocity = direction * thrustForce;
        }

        public override void Rotate(Vector2 direction)
        { 
            // Alien ships don't rotate
        }
        
        private void HandleScreenWrapping()
        {
            var currentPosition = _rigidbody2D.position;
            var wrappedPosition = ScreenWrapping.Instance.GetWrappedPosition(currentPosition);
            _rigidbody2D.position = wrappedPosition;
        }
    }
}
