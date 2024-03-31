using System;
using UnityEngine;

namespace CollisionHandler
{
    public class PlayerCollisionHandler : MonoBehaviour
    {
        public event Action OnPlayerDied;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("EnemyBullet") || other.CompareTag("Enemy") || other.CompareTag("Edge"))
            {
                OnPlayerDied?.Invoke();
            }
        }
    }
}
