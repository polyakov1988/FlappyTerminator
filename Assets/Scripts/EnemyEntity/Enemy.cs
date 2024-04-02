using Mover;
using Pool;
using Score;
using Spawner;
using UnityEngine;

namespace EnemyEntity
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyBulletSpawner _bulletSpawner;
        [SerializeField] private EnemyMover _enemyMover;
        [SerializeField] private EnemyDeath _enemyDeath;

        private void OnEnable()
        {
            _enemyMover.SetSpeed();
            _bulletSpawner.StartShoot();
        }

        private void OnDisable()
        {
            _bulletSpawner.StopShoot();
        }
        
        private void Start()
        {
            _bulletSpawner.StartShoot();
        }

        public void Init(EnemyPool enemyPool, ExplosionSpawner explosionSpawner, 
            ScoreCounter scoreCounter, EnemyBulletPool enemyBulletPool)
        {
            _enemyDeath.Init(enemyPool, explosionSpawner, scoreCounter);
            _bulletSpawner.Init(enemyBulletPool);
        }

        public void Reset()
        {
            _bulletSpawner.Reset();
        }
    }
}
