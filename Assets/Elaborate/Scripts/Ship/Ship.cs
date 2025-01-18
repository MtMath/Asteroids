using NoTask.Asteroids.Base;
using UnityEngine;

namespace NoTask.Asteroids.Ship
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class Ship : SpaceObject
    {
        [Header("Ship Properties")]
        [SerializeField] protected float thrustForce = 5f;
        [SerializeField] protected float rotationSpeed = 200f;
        
        protected Rigidbody2D _rigidbody2D;
        
        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }
        
        public abstract void Shoot();
        public abstract void Move(Vector2 direction);
        public abstract void Rotate(Vector2 direction);
    }
}