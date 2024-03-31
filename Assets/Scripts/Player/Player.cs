using Mover;
using Spawner;
using UnityEngine;

namespace Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Score.Score _score;
        [SerializeField] private PlayerMover _playerMover;
        [SerializeField] private PlayerBulletSpawner _playerBulletSpawner;
    
        public void Reset()
        {
            _score.Reset();
            _playerMover.Reset();
            _playerBulletSpawner.Reset();
        }
    }
}
