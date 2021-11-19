using Pirate.Scripts.Components;
using UnityEngine;


namespace Pirate.Scripts {
    public class PlayerController : MonoBehaviour {

        [SerializeField] private float speed;
        [SerializeField] private float jumpForce;
        [SerializeField] private CheckCollider checkController;

        private Rigidbody2D _rigidbody;
        private Controls _controls;

        private float _direction;
        
        
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
            if (!checkController.isGround) return;
            _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            checkController.isGround = false;
        }
    }
}