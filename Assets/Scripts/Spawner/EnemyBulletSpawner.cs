using System.Collections;
using Bullet;
using Pool;
using UnityEngine;

namespace Spawner
{
    public class EnemyBulletSpawner : MonoBehaviour
    {
        private EnemyBulletPool _bulletPool;
    
        private WaitForSeconds _bulletSpawnTime;
        private bool _isShootingActive;

        private void Awake()
        {
            _bulletPool = FindObjectOfType<EnemyBulletPool>();
        
            _bulletSpawnTime = new(2);
        }

        public void StartShoot()
        {
            _isShootingActive = true;
            StartCoroutine(Spawn());
        }
    
        public void StopShoot()
        {
            _isShootingActive = false;
        }

        private IEnumerator Spawn()
        {
            while (_isShootingActive)
            {
                yield return _bulletSpawnTime;
                
                EnemyBullet bullet = _bulletPool.GetObject();

                bullet.transform.SetParent(transform);
                bullet.transform.position = transform.position;
            }
        }

        public void Reset()
        {
            Component[] bullets = transform.GetComponentsInChildren(typeof(EnemyBullet), false);

            foreach (var bullet in bullets)
            {
                _bulletPool.PutObject((EnemyBullet) bullet);
            }
        }
    }
}
