using System;
using NoTask.Asteroids.Base;
using UnityEngine;

namespace Projectile
{
    public abstract class Projectile : SpaceObject
    {
        public GameObject Owner { get; private set; }
        public Vector2 Direction { get; private set; }
        public Vector2 Force { get; private set; }
        
        public Action OnShoot;
        
        public void Shoot(GameObject owner, Vector2 direction, float force)
        {
            Owner = owner;
            Direction = direction;
            Force = direction * force;
            OnShoot?.Invoke();
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            if(!gameObject.CompareTag("Projectile")) gameObject.tag = "Projectile";
        }
#endif
    }
}