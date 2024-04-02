using System;
using CollisionHandler;
using Spawner;
using UnityEngine;

namespace PlayerEntity
{
    public class PlayerDeath : MonoBehaviour
    {
        [SerializeField] private PlayerCollisionHandler _playerCollisionHandler;
        [SerializeField] private ExplosionSpawner _explosionSpawner;

        public event Action Died;
    
        private void OnEnable()
        {
            _playerCollisionHandler.Died += Die;
        }
        
        private void OnDisable()
        {
            _playerCollisionHandler.Died -= Die;
        }
        
        private void Die()
        {
            _explosionSpawner.Explode(transform.position);
            Died?.Invoke();
            gameObject.SetActive(false);
        }

    
    }
}
