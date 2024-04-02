using System;
using Bullet;
using PlayerEntity;
using UnityEngine;

namespace CollisionHandler
{
    public class EnemyCollisionHandler : MonoBehaviour
    {
        public event Action Died;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out PlayerBullet playerBullet) || other.TryGetComponent(out Player player))
            {
                Died?.Invoke();
            }
        }
    }
}
