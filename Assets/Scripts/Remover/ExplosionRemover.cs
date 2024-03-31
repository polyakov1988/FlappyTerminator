using System;
using Pool;
using UnityEngine;

namespace Remover
{
    public class ExplosionRemover : MonoBehaviour
    {
        private ExplosionPool _explosionPool;
        private Explosion.Explosion _explosion;

        private void Awake()
        {
            _explosionPool = GameObject.FindGameObjectWithTag("ExplosionPool").GetComponent<ExplosionPool>();
            _explosion = gameObject.GetComponent<Explosion.Explosion>();
        }

        //Used by Animation Event on the last frame
        public void Remove()
        {
            _explosionPool.PutObject(_explosion);
        }
    }
}
