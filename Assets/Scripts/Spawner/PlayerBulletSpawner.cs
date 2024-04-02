using System.Collections;
using Bullet;
using Pool;
using UnityEngine;

namespace Spawner
{
    public class PlayerBulletSpawner : MonoBehaviour
    {
        [SerializeField] private PlayerBulletPool _bulletPool;

        private bool _canShoot;
        private WaitForSeconds _shootingTimeout;
        private KeyCode _shootKey;

        private void Awake()
        {
            _shootingTimeout = new(1);
            _canShoot = true;
            _shootKey = KeyCode.Mouse1;
        }

        private void Update()
        {
            if (Input.GetKeyDown(_shootKey) && _canShoot)
            {
                StartCoroutine(Shoot());
            }
        }

        private IEnumerator Shoot()
        {
            _canShoot = false;
        
            PlayerBullet bullet = _bulletPool.GetObject();
            bullet.Init(_bulletPool);
            bullet.transform.position = transform.position;
            
            yield return _shootingTimeout;

            _canShoot = true;
        }

        public void Reset()
        {
            PlayerBullet[] bullets = FindObjectsOfType<PlayerBullet>();

            foreach (var bullet in bullets)
            {
                _bulletPool.PutObject(bullet);
            }
        }
    }
}
