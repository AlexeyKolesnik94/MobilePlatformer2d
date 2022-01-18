using System;
using UnityEngine;
using UnityEngine.Events;

namespace Pirate.Scripts {
    public class CheckCollider : MonoBehaviour {
    
        [SerializeField] private string component;
        [SerializeField] private EnterEvent action;
        
        
        public bool isGround;
    
        private void OnCollisionEnter2D(Collision2D other) {
            isGround = other.collider.GetComponent<Ground>();
            
            if (other.collider.GetComponent(component)) {
                action?.Invoke(other.gameObject);
            }
        }
        
        [Serializable]
        public class EnterEvent : UnityEvent<GameObject> {
            
        }
        
    }
}