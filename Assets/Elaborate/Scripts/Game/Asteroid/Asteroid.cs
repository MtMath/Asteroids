using Managers;
using UnityEngine;
using NoTask.Asteroids.Base;
using Random = UnityEngine.Random;

namespace NoTask.Asteroids.Asteroid
{
    [RequireComponent(typeof(SpriteRenderer)), RequireComponent(typeof(Rigidbody2D))]
    public sealed class Asteroid : SpaceObject
    {
        [Header("Asteroid Settings")]
        public AsteroidStats stats;
        public float size;
        
        public int ScoreValue
        {
            get
            {
                return size switch
                {
                    < 0.7f => 100,
                    < 1.4f => 50,
                    _ => 20
                };
            }
        }

        private SpriteRenderer _spriteRenderer;
        private Rigidbody2D _rigidbody2D;
        
        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            transform.eulerAngles = new Vector3(0f, 0f, Random.value * 360f);
            transform.localScale = Vector3.one * size;
            
            _rigidbody2D.mass = size;
        }

        private void OnDisable()
        {
            _rigidbody2D.velocity = Vector2.zero;
            _rigidbody2D.angularVelocity = 0f;
        }

        private void FixedUpdate()
        {
            HandleScreenWrapping();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.gameObject.CompareTag("Projectile")) return;
            HandleImpact(other);
        }

        public void InitializeMovement()
        {
            var direction = Random.insideUnitCircle.normalized;
            var speed = Random.Range(stats.minSpeed, stats.maxSpeed);
            
            var variance = Random.Range(-10, 10);
            var rotation = Quaternion.AngleAxis(variance, Vector3.forward);
            
            var trajectory = rotation * -direction;
            _rigidbody2D.AddForce(trajectory * speed);
        }
        
        public void SetSprite(Sprite sprite)
        {
            _spriteRenderer.sprite = sprite;
        }
        
        private void HandleScreenWrapping()
        {
            var currentPosition = _rigidbody2D.position;
            var wrappedPosition = ScreenWrapping.Instance.GetWrappedPosition(currentPosition);
            _rigidbody2D.position = wrappedPosition;
        }

        private void HandleImpact(Collision2D other)
        {
            //TODO: Handle impact
            
            if (size * 0.5f >= stats.minSize)
            {
                SplitAsteroid();
                SplitAsteroid();
            }
            
            /*var projectileRb = other.rigidbody;
            var impactDirection = other.relativeVelocity.normalized;

            var impactForce = projectileRb.mass * projectileRb.velocity.magnitude;
            var impactPoint = other.contacts[0].point;

            var force = impactDirection * impactForce;

            _rigidbody2D.AddForceAtPosition(force, impactPoint, ForceMode2D.Impulse);
            */
            
            GameManager.Instance.OnAsteroidDestroyed?.Invoke(this);
            Destroy(gameObject);
        }
        
        public Asteroid SplitAsteroid()
        {
            Vector2 position = transform.position;
            position += Random.insideUnitCircle * 0.5f;
            
            //Get from pool
            var asteroid = Instantiate(this, position, transform.rotation);
            asteroid.size = size * 0.5f;
            
            asteroid.InitializeMovement();
            
            return asteroid;
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (!gameObject.CompareTag("Asteroid")) gameObject.tag = "Asteroid";
            if (!_spriteRenderer) _spriteRenderer = GetComponent<SpriteRenderer>();
        }
#endif
    }
}