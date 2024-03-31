using Mover;
using Spawner;
using UnityEngine;

namespace Enemy
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyBulletSpawner _bulletSpawner;
        [SerializeField] private EnemyMover _enemyMover;

        private void Start()
        {
            _bulletSpawner.StartShoot();
        }

        private void OnEnable()
        {
            _enemyMover.SetSpeed();
            _bulletSpawner.StartShoot();
        }

        private void OnDisable()
        {
            _bulletSpawner.StopShoot();
        }

        public void Reset()
        {
            _bulletSpawner.Reset();
        }
    }
}
