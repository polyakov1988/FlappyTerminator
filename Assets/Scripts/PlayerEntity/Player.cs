using Mover;
using Score;
using Spawner;
using UnityEngine;

namespace PlayerEntity
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private ScoreCounter _scoreCounter;
        [SerializeField] private PlayerMover _playerMover;
        [SerializeField] private PlayerBulletSpawner _playerBulletSpawner;
    
        public void Reset()
        {
            _scoreCounter.Reset();
            _playerMover.Reset();
            _playerBulletSpawner.Reset();
        }
    }
}
