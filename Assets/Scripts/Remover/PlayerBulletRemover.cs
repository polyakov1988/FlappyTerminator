using Bullet;
using Pool;
using UnityEngine;

namespace Remover
{
    public class PlayerBulletRemover : MonoBehaviour
    {
        [SerializeField] private PlayerBulletPool _bulletPool;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out PlayerBullet playerBullet))
            {
                _bulletPool.PutObject(playerBullet);
            }
        }
    }
}
