using Pool;
using UnityEngine;

namespace Bullet
{
    public class PlayerBullet : MonoBehaviour
    {
        [SerializeField] private PlayerBulletKillEnemyListener _killEnemyListener;

        public void Init(PlayerBulletPool bulletPool)
        {
            _killEnemyListener.Init(bulletPool);
        }
    }
}
