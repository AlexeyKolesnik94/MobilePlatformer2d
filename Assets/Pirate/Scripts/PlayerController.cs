using System;
using UnityEngine;


namespace Pirate.Scripts {
    public class PlayerController : MonoBehaviour {

        [SerializeField] private float speed;
        [SerializeField] private float jumpForce;

        private Rigidbody2D _rigidbody;
        private Controls _controls;

        private float _direction;
        private bool _isGround;

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

        private void OnCollisionEnter2D(Collision2D other) {
            _isGround = other.collider.GetComponent<Ground>();
        }


        private void Move() {
            _direction = _controls.Player.Move.ReadValue<float>();
            _rigidbody.velocity = new Vector2(_direction * speed, _rigidbody.velocity.y);
        }
        
        
        private void Jump() {
            if (!_isGround) return;
            _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            _isGround = false;
        }
        
        
    }
}