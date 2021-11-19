using UnityEngine;
using UnityEngine.Events;

namespace Pirate.Scripts.Components {
    public class CheckControllerComponent : MonoBehaviour {

        [SerializeField] private string component;
        [SerializeField] private UnityEvent action;
    
        public bool isGround;
    
        private void OnCollisionEnter2D(Collision2D other) {
            Ground ground = other.collider.GetComponent<Ground>();
            if (!ground) return;
            isGround = true;
        }

        private void OnTriggerEnter2D(Collider2D other) {
            if (other.GetComponent(component)) {
                action.Invoke();
            }

        }
    }
}