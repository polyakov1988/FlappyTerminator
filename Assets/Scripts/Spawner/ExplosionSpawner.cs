using Pool;
using UnityEngine;

namespace Spawner
{
    public class ExplosionSpawner : MonoBehaviour
    {
        [SerializeField] private ExplosionPool _explosionPool;

        public void Explode(Vector3 position)
        {
            Explosion.Explosion explosion = _explosionPool.GetObject();

            explosion.transform.position = position;
        }
    }
}
