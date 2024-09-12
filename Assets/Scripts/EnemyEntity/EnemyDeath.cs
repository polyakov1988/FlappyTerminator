using CollisionHandler;
using Pool;
using Score;
using Spawner;
using UnityEngine;

namespace EnemyEntity
{
    public class EnemyDeath : MonoBehaviour
    {
        [SerializeField] private EnemyCollisionHandler _enemyCollisionHandler;
        [SerializeField] private Enemy _enemy;

        private ExplosionSpawner _explosionSpawner;
        private EnemyPool _enemyPool;
        private ScoreCounter _scoreCounter;

        private void OnEnable()
        {
            _enemyCollisionHandler.Died += Die;
        }
        
        private void OnDisable()
        {
            _enemyCollisionHandler.Died -= Die;
        }

        public void Init(EnemyPool enemyPool, ExplosionSpawner explosionSpawner, ScoreCounter scoreCounter)
        {
            _enemyPool = enemyPool;
            _explosionSpawner = explosionSpawner;
            _scoreCounter = scoreCounter;
        }

        private void Die()
        {
            _enemyPool.PutObject(_enemy);
            _explosionSpawner.Explode(transform.position);
            _scoreCounter.Increment();
        }
    }
}
