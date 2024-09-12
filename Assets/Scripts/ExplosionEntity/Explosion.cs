using Pool;
using Remover;
using UnityEngine;

namespace ExplosionEntity
{
    public class Explosion : MonoBehaviour
    {
        [SerializeField] private ExplosionRemover _explosionRemover;

        public void Init(ExplosionPool explosionPool)
        {
            _explosionRemover.Init(explosionPool);
        }
    }
}
