using UnityEngine;

namespace Pirate.Scripts {
    public class PlayerController : MonoBehaviour {

        [SerializeField] private float speed;

        private Rigidbody2D _rigidbody;
        private Controls _controls;
        private float _direction;

        private void Awake() {
            _rigidbody = GetComponent<Rigidbody2D>();
            _controls = new Controls();
        }

        private void FixedUpdate() {
            Move();
        }
        
        private void OnEnable() => _controls.Enable();

        private void OnDisable() => _controls.Disable();
        
        private void Move() {
            _direction = _controls.Player.Move.ReadValue<float>();
            _rigidbody.velocity = new Vector2(_direction * speed, _rigidbody.velocity.y);
        }
    }
}