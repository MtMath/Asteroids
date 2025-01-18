using UnityEngine;

namespace Projectile
{
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class Bullet : Projectile
    {
        private Rigidbody2D _rigidbody2D;
        
        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void OnEnable()
        {
            OnShoot += HandleShoot;
        }
        
        private void OnDisable()
        {
            OnShoot -= HandleShoot;
        }

        private void HandleShoot()
        {
            _rigidbody2D.AddForce(Force);
            
            //TODO: BulletPool
            Destroy(gameObject, 1.2f);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Asteroid"))
            {
                //TODO: HandlePool() - BulletPool, HandleImpact(), HandleVFX(), HandleSFX()
                Destroy(gameObject);
            }
        }
    }
}