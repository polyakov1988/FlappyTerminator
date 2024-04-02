using ExplosionEntity;
using Pool;
using UnityEngine;

namespace Remover
{
    public class ExplosionRemover : MonoBehaviour
    {
        private ExplosionPool _explosionPool;
        private Explosion _explosion;

        private void Awake()
        {
            _explosion = gameObject.GetComponent<Explosion>();
        }

        public void Init(ExplosionPool explosionPool)
        {
            _explosionPool = explosionPool;
        }

        //Used by Animation Event on the last frame
        public void Remove()
        {
            _explosionPool.PutObject(_explosion);
        }
    }
}
