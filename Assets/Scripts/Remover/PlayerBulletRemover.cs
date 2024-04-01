using Pool;
using UnityEngine;

namespace Remover
{
    public class PlayerBulletRemover : MonoBehaviour
    {
        [SerializeField] private PlayerBulletPool _bulletPool;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("PlayerBullet"))
            {
                _bulletPool.PutObject(other.GetComponent<Bullet.Bullet>());
            }
        }
    }
}
