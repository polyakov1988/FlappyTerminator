using CollisionHandler;
using Pool;
using UnityEngine;

namespace Bullet
{
    public class PlayerBulletKillEnemyListener : MonoBehaviour
    {
        [SerializeField] private PlayerBulletCollisionHandler _playerBulletCollisionHandler;
        [SerializeField] private PlayerBullet _bullet;
    
        private PlayerBulletPool _bulletPool;

        private void OnEnable()
        {
            _playerBulletCollisionHandler.EnemyKilled += MoveIntoPool;
        }
        
        private void OnDisable()
        {
            _playerBulletCollisionHandler.EnemyKilled -= MoveIntoPool;
        }

        public void Init(PlayerBulletPool bulletPool)
        {
            _bulletPool = bulletPool;
        } 

        private void MoveIntoPool()
        {
            _bulletPool.PutObject(_bullet);
        }
    }
}
