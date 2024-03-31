using System.Collections.Generic;
using UnityEngine;

namespace Pool
{
    public abstract class BasePool<T> : MonoBehaviour where T : MonoBehaviour
    {
        [SerializeField] private T _prefab;
    
        private Queue<T> _queue;
    
        protected void Awake()
        {
            _queue = new Queue<T>();
        }

        public T GetObject()
        {
            if (_queue.Count == 0)
            {
                return Instantiate(_prefab);
            }

            T entity = _queue.Dequeue();
            entity.gameObject.SetActive(true);
        
            return entity;
        }

        public void PutObject(T entity)
        {
            entity.gameObject.SetActive(false);
            _queue.Enqueue(entity);
        }
    }
}
