using System;
using Bullet;
using EdgeEntity;
using EnemyEntity;
using UnityEngine;

namespace CollisionHandler
{
    public class PlayerCollisionHandler : MonoBehaviour
    {
        public event Action PlayerDied;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out EnemyBullet enemyBullet) 
                || other.TryGetComponent(out Enemy enemy) 
                || other.TryGetComponent(out Edge edge))
            {
                PlayerDied?.Invoke();
            }
        }
    }
}
