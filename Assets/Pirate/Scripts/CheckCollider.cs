using System;
using UnityEngine;
using UnityEngine.Events;

namespace Pirate.Scripts {
    public class CheckCollider : MonoBehaviour {
    
        [SerializeField] private string component;
        [SerializeField] private EnterEvent action;
        
        public bool isGround;
    
        private void OnCollisionEnter2D(Collision2D other) {
            Ground ground = other.collider.GetComponent<Ground>();
            if (!ground) return;
            
            if (other.collider.GetComponent(component)) {
                action?.Invoke(other.gameObject);
            }
            
        }
        
        [Serializable]
        public class EnterEvent : UnityEvent<GameObject> {
            
        }
        
    }
}