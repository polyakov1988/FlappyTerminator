using System.Collections;
using Pool;
using UnityEngine;

namespace Spawner
{
    public class PlayerBulletSpawner : MonoBehaviour
    {
        [SerializeField] private PlayerBulletPool _bulletPool;

        private bool _canShoot;
        private WaitForSeconds _shootingTimeout;

        private void Awake()
        {
            _shootingTimeout = new(1);
            _canShoot = true;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse1) && _canShoot)
            {
                StartCoroutine(Shoot());
            }
        }

        private IEnumerator Shoot()
        {
            _canShoot = false;
        
            Bullet.Bullet bullet = _bulletPool.GetObject();
            bullet.transform.position = transform.position;
            
            yield return _shootingTimeout;

            _canShoot = true;
        }

        public void Reset()
        {
            GameObject[] bullets = GameObject.FindGameObjectsWithTag("PlayerBullet");

            foreach (var bullet in bullets)
            {
                _bulletPool.PutObject(bullet.GetComponent<Bullet.Bullet>());
            }
        }
    }
}
