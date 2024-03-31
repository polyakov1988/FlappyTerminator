using CollisionHandler;
using Pool;
using Spawner;
using UnityEngine;

namespace Enemy
{
    public class EnemyDeath : MonoBehaviour
    {
        [SerializeField] private EnemyCollisionHandler _enemyCollisionHandler;
        [SerializeField] private Enemy _enemy;

        private ExplosionSpawner _explosionSpawner;
        private EnemyPool _enemyPool;
        private Score.Score _score;

        private void OnEnable()
        {
            _enemyCollisionHandler.OnEnemyDied += Die;
        }

        private void Awake()
        {
            _enemyPool = GameObject.FindGameObjectWithTag("EnemyPool").GetComponent<EnemyPool>();
            _explosionSpawner = GameObject.FindGameObjectWithTag("ExplosionSpawner").GetComponent<ExplosionSpawner>();
            _score = GameObject.FindGameObjectWithTag("Score").GetComponent<Score.Score>();
        }

        private void Die()
        {
            _enemyPool.PutObject(_enemy);
            _explosionSpawner.Explode(transform.position);
            _score.Increment();
        }

        private void OnDisable()
        {
            _enemyCollisionHandler.OnEnemyDied -= Die;
        }
    }
}
