using UnityEngine;

namespace Mover
{
    public class EnemyMover : MonoBehaviour
    {
        [SerializeField] private float _minSpeed;
        [SerializeField] private float _maxSpeed;
        
        private float _speed;

        public void SetSpeed()
        {
            _speed = Random.Range(_minSpeed, _maxSpeed);
        }
    
        private void Update()
        {
            transform.position += Vector3.left * _speed * Time.deltaTime;
        }
    }
}
