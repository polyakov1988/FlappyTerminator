using CollisionHandler;
using Pool;
using UnityEngine;

namespace Bullet
{
    public class PlayerBulletKillEnemyListener : MonoBehaviour
    {
        [SerializeField] private PlayerBulletCollisionHandler _playerBulletCollisionHandler;
        [SerializeField] private Bullet _bullet;
    
        private PlayerBulletPool _bulletPool;

        private void OnEnable()
        {
            _playerBulletCollisionHandler.EnemyKilled += MoveIntoPool;
        }

        private void Awake()
        {
            _bulletPool = FindObjectOfType<PlayerBulletPool>();
        }
    
        private void OnDisable()
        {
            _playerBulletCollisionHandler.EnemyKilled -= MoveIntoPool;
        }

        private void MoveIntoPool()
        {
            _bulletPool.PutObject(_bullet);
        }
    }
}
