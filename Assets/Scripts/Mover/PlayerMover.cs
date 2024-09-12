using UnityEngine;

namespace Mover
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private float _velocity;

        private Rigidbody2D _rigidbody;
        private Vector3 _startPosition;
        private KeyCode _jumpKey;
    
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _startPosition = transform.position;
            _jumpKey = KeyCode.Mouse0;
        }

        private void Update()
        {
            if (Input.GetKeyDown(_jumpKey))
            {
                _rigidbody.velocity = Vector2.zero;
                _rigidbody.velocity += Vector2.up * _velocity;
            }
        }

        public void Reset()
        {
            transform.position = _startPosition;
        }
    }
}
