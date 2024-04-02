using ExplosionEntity;
using Pool;
using Remover;
using UnityEngine;

namespace Spawner
{
    public class ExplosionSpawner : MonoBehaviour
    {
        [SerializeField] private ExplosionPool _explosionPool;

        public void Explode(Vector3 position)
        {
            Explosion explosion = _explosionPool.GetObject();
            explosion.Init(_explosionPool);
            
            explosion.transform.position = position;
        }
    }
}
