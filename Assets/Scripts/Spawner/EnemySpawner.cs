using System.Collections;
using System.Collections.Generic;
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

        private List<Enemy.Enemy> _enemies = new();

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
                Enemy.Enemy enemy = _enemyPool.GetObject();
                enemy.transform.SetParent(transform);
                enemy.transform.position = new Vector3(transform.position.x, Random.Range(_minY, _maxY));

                yield return _enemySpawnTime;
            }
        }

        public void Reset()
        {
            Component[] enemies = transform.GetComponentsInChildren(typeof(Enemy.Enemy), false);

            foreach (var entity in enemies)
            {
                Enemy.Enemy enemy = (Enemy.Enemy)entity;

                enemy.Reset();
                
                _enemyPool.PutObject(enemy);
            }
        }
    }
}