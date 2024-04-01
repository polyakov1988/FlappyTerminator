using Bullet;
using Pool;
using UnityEngine;

namespace Remover
{
    public class EnemyBulletRemover : MonoBehaviour
    {
        [SerializeField] private EnemyBulletPool _bulletPool;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out EnemyBullet enemyBullet))
            {
                _bulletPool.PutObject(enemyBullet);
            }
        }
    }
}
