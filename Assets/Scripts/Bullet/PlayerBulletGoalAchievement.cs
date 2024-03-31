using CollisionHandler;
using Pool;
using UnityEngine;

namespace Bullet
{
    public class PlayerBulletGoalAchievement : MonoBehaviour
    {
        [SerializeField] private PlayerBulletCollisionHandler _playerBulletCollisionHandler;
        [SerializeField] private Bullet _bullet;
    
        private BulletPool _bulletPool;

        private void OnEnable()
        {
            _playerBulletCollisionHandler.OnGoalAchieved += MoveIntoPool;
        }

        private void Awake()
        {
            _bulletPool = GameObject.FindGameObjectWithTag("PlayerBulletPool").GetComponent<BulletPool>();
        }
    
        private void OnDisable()
        {
            _playerBulletCollisionHandler.OnGoalAchieved -= MoveIntoPool;
        }

        private void MoveIntoPool()
        {
            _bulletPool.PutObject(_bullet);
        }
    }
}
