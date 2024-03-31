using System;
using CollisionHandler;
using Spawner;
using UnityEngine;

namespace Player
{
    public class PlayerDeath : MonoBehaviour
    {
        [SerializeField] private PlayerCollisionHandler _playerCollisionHandler;

        private ExplosionSpawner _explosionSpawner;

        public event Action OnGameEnded;
    
        private void OnEnable()
        {
            _playerCollisionHandler.OnPlayerDied += Die;
        }

        private void Awake()
        {
            _explosionSpawner = GameObject.FindGameObjectWithTag("ExplosionSpawner").GetComponent<ExplosionSpawner>();
        }
    
        private void OnDisable()
        {
            _playerCollisionHandler.OnPlayerDied -= Die;
        }

        private void Die()
        {
            _explosionSpawner.Explode(transform.position);
            OnGameEnded?.Invoke();
            gameObject.SetActive(false);
        }

    
    }
}
