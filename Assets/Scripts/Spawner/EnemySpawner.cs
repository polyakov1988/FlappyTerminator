using System.Collections;
using EnemyEntity;
using Pool;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Spawner
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private EnemyPool _enemyPool;
        [SerializeField] private float _minY;
        [SerializeField] private float _maxY;
    
        private WaitForSeconds _enemySpawnTime;
        private bool _isSpawnActive;

        private void Awake()
        {
            _enemySpawnTime = new(2);
            _isSpawnActive = true;
        }

        private void Start()
        {
            StartCoroutine(Spawn());
        }

        private IEnumerator Spawn()
        {
            while (_isSpawnActive)
            {
                Enemy enemy = _enemyPool.GetObject();
                enemy.transform.SetParent(transform);
                enemy.transform.position = new Vector3(transform.position.x, Random.Range(_minY, _maxY));

                yield return _enemySpawnTime;
            }
        }

        public void Reset()
        {
            Component[] enemies = transform.GetComponentsInChildren(typeof(Enemy), false);

            foreach (var entity in enemies)
            {
                Enemy enemy = (Enemy)entity;

                enemy.Reset();
                
                _enemyPool.PutObject(enemy);
            }
        }
    }
}