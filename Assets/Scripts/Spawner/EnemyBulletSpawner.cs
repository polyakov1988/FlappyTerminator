using System.Collections;
using Pool;
using UnityEngine;

namespace Spawner
{
    public class EnemyBulletSpawner : MonoBehaviour
    {
        private BulletPool _bulletPool;
    
        private WaitForSeconds _bulletSpawnTime;
        private bool _isShootingActive;

        private void Awake()
        {
            _bulletPool = GameObject.FindGameObjectWithTag("EnemyBulletPool").GetComponent<BulletPool>();
        
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
                
                Bullet.Bullet bullet = _bulletPool.GetObject();

                bullet.transform.SetParent(transform);
                bullet.transform.position = transform.position;
            }
        }

        public void Reset()
        {
            Component[] bullets = transform.GetComponentsInChildren(typeof(Bullet.Bullet), false);

            foreach (var bullet in bullets)
            {
                _bulletPool.PutObject((Bullet.Bullet) bullet);
            }
        }
    }
}
