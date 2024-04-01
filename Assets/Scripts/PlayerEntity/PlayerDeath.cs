using System;
using CollisionHandler;
using Spawner;
using UnityEngine;

namespace PlayerEntity
{
    public class PlayerDeath : MonoBehaviour
    {
        [SerializeField] private PlayerCollisionHandler _playerCollisionHandler;

        private ExplosionSpawner _explosionSpawner;

        public event Action Died;
    
        private void OnEnable()
        {
            _playerCollisionHandler.PlayerDied += Die;
        }

        private void Awake()
        {
            _explosionSpawner = FindObjectOfType<ExplosionSpawner>();
        }
    
        private void OnDisable()
        {
            _playerCollisionHandler.PlayerDied -= Die;
        }

        private void Die()
        {
            _explosionSpawner.Explode(transform.position);
            Died?.Invoke();
            gameObject.SetActive(false);
        }

    
    }
}
