using System;
using UnityEngine;
using UnityEngine.Pool;

namespace Utils.Patterns
{
    [Serializable]
    public class Pool<T> : MonoBehaviour where T : Component
    {
        private ObjectPool<T> _pool;
        [SerializeField] private T prefab;
        [SerializeField] private Transform parent;
        [SerializeField] private int initialSize = 5;
        [SerializeField] private int maxSize = 10;

        public void Start()
        {
            Debug.Log("Pool Start " + typeof(T).Name);
            
            _pool = new ObjectPool<T>(
                createFunc: CreateObject,
                actionOnGet: OnObjectGet,
                actionOnRelease: OnObjectRelease,
                actionOnDestroy: DestroyObject,
                defaultCapacity: initialSize,
                maxSize: maxSize
            );
        }

        private T CreateObject()
        {
            var obj = Instantiate(prefab, parent);
            obj.gameObject.SetActive(false);
            return obj;
        }

        private static void OnObjectGet(T obj)
        {
            obj.gameObject.SetActive(true);
        }

        private static void OnObjectRelease(T obj)
        {
            obj.gameObject.SetActive(false);
        }

        private static void DestroyObject(T obj)
        {
            Destroy(obj.gameObject);
        }

        public T Get()
        {
            return _pool.Get();
        }
        public void Release(T obj)
        {
            _pool.Release(obj);
        }
    }
}