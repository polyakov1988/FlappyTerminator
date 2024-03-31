using Mover;
using Pool;
using UnityEngine;

namespace Remover
{
    public class EnemyRemover : MonoBehaviour
    {
        [SerializeField] private EnemyPool _enemyPool;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Enemy"))
            {
                _enemyPool.PutObject(other.GetComponent<Enemy.Enemy>());
            }
        }
    }
}
