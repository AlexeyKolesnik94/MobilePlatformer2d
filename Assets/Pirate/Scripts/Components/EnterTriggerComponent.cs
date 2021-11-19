using UnityEngine;
using UnityEngine.Events;

namespace Pirate.Scripts.Components {
    public class EnterTriggerComponent : MonoBehaviour {

        [SerializeField] private string component;
        [SerializeField] private UnityEvent action;
        
        
        private void OnTriggerEnter2D(Collider2D other) {
            if (other.GetComponent(component)) {
                action?.Invoke();
            }

        }
    }
}