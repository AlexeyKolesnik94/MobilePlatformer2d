using UnityEngine;

namespace Pirate.Scripts {
    public class PlayerController : MonoBehaviour {

        [SerializeField] private float speed;
        [SerializeField] private float jumpForce;

        private Rigidbody2D _rigidbody;
        private Controls _controls;
        private float _direction;
        private bool _isGround;
        private bool _isJumping;

        private void Awake() {
            _rigidbody = GetComponent<Rigidbody2D>();
            _controls = new Controls();

            _controls.Player.Jump.performed += context => Jump();
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
        
        
        private void Jump() {
            //if (!_isGround) return;
            _rigidbody.velocity = Vector2.up * jumpForce;
            _isGround = false;
            _isJumping = true; 
        }
        
        
    }
}