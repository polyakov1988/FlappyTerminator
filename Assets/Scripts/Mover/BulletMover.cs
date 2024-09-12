using UnityEngine;

namespace Mover
{
    public class BulletMover : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private Vector3 _direction;
    
        private void Update()
        {
            transform.position += _direction * _speed * Time.deltaTime;
        }
    }
}
