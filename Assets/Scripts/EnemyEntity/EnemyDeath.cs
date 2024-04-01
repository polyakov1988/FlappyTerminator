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
            _enemyCollisionHandler.EnemyDied += Die;
        }

        private void Awake()
        {
            _enemyPool = FindObjectOfType<EnemyPool>();
            _explosionSpawner = FindObjectOfType<ExplosionSpawner>();
            _scoreCounter = FindObjectOfType<ScoreCounter>();
        }

        private void Die()
        {
            _enemyPool.PutObject(_enemy);
            _explosionSpawner.Explode(transform.position);
            _scoreCounter.Increment();
        }

        private void OnDisable()
        {
            _enemyCollisionHandler.EnemyDied -= Die;
        }
    }
}
