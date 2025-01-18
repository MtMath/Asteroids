using UnityEngine;

namespace Game.Managers
{
    public abstract class Spawner<T> : MonoBehaviour where T : MonoBehaviour
    {
        public abstract void Spawn();
    }
}