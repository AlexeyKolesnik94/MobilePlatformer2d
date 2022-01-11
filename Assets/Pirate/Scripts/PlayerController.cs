using System;
using UnityEngine;

namespace Pirate.Scripts {
    public class PlayerController : MonoBehaviour {

        [SerializeField] private float speed;
        [SerializeField] private float jumpForce;
        [SerializeField] private float damageJumpForce;
        [SerializeField] private CheckCollider checkController;

        private Rigidbody2D _rigidbody;
        private Controls _controls;
        private Animator _animator;

        private float _direction;
        
        private static readonly int IsRunning = Animator.StringToHash("is-running");
        private static readonly int VerticalVelocity = Animator.StringToHash("vertical-velocity");
        private static readonly int IsGround = Animator.StringToHash("is-ground");
        private static readonly int Hit = Animator.StringToHash("hit");
        private bool _isDirectionRight;


        private void Awake() {
            _rigidbody = GetComponent<Rigidbody2D>();
            _controls = new Controls();
            _animator = GetComponent<Animator>();

            _controls.Player.Jump.performed += context => Jump();
        }

        private void Update() {
            switch (_isDirectionRight) {
                case false when _direction < 0:
                case true when _direction > 0:
                    Flip();
                    break;
            }
        }

        private void FixedUpdate() {
            Move();
            _animator.SetBool(IsGround, checkController.isGround);
            _animator.SetFloat(VerticalVelocity, _rigidbody.velocity.y);
            _animator.SetBool(IsRunning, _direction != 0);
        }
        
        private void OnEnable() => _controls.Enable();

        private void OnDisable() => _controls.Disable();


        private void Move() {
            _direction = _controls.Player.Move.ReadValue<float>();
            _rigidbody.velocity = new Vector2(_direction * speed, _rigidbody.velocity.y);
        }

        private void Flip() {
            _isDirectionRight = !_isDirectionRight;
            Vector3 scaler = transform.localScale;
            scaler.x *= -1;
            transform.localScale = scaler;
        }
        
        
        private void Jump() {
            if (!checkController.isGround) return;
            _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            checkController.isGround = false;
        }

        public void TakeDamage() {
            _animator.SetTrigger(Hit);
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, damageJumpForce);
            Debug.Log("damage");
        }
    }
}