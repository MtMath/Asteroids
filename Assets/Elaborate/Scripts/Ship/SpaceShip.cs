using Projectile;
using UnityEngine;

namespace NoTask.Asteroids.Ship
{
    public sealed class SpaceShip : Ship
    {
        public Bullet bulletPrefab;
        public Transform firePoint;
        public Rigidbody2D Rigidbody => _rigidbody2D;
        
        public override void Shoot()
        {
            var bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            bullet.Shoot(gameObject,firePoint.up, 200);
        }

        public override void Move(Vector2 direction)
        {
            Vector2 thrustDirection = transform.up;
            var force= thrustDirection * thrustForce * direction.y;
            
            _rigidbody2D.AddForce(force);
        }

        public override void Rotate(Vector2 direction)
        {
            _rigidbody2D.angularVelocity = direction.x * -rotationSpeed;
        }
    }
}