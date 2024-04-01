using System;
using UnityEngine;

namespace CollisionHandler
{
    public class PlayerBulletCollisionHandler : MonoBehaviour
    {
        public event Action EnemyKilled;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Enemy"))
            {
                EnemyKilled?.Invoke();
            }
        }
    }
}
