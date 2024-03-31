using System;
using UnityEngine;

namespace CollisionHandler
{
    public class EnemyCollisionHandler : MonoBehaviour
    {
        public event Action OnEnemyDied;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("PlayerBullet") || other.CompareTag("Player"))
            {
                OnEnemyDied?.Invoke();
            }
        }
    }
}
