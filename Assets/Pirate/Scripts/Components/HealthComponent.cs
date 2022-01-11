using UnityEngine;
using UnityEngine.Events;

namespace Pirate.Scripts.Components {
    public class HealthComponent : MonoBehaviour {

        [SerializeField] private int health;
        [SerializeField] private UnityEvent onDamage;
        [SerializeField] private UnityEvent onDie;

        public void ApplyDamage(int damageValue) {
            health -= damageValue;
            onDamage?.Invoke();
            if (health <= 0) {
                onDie?.Invoke();
            }
        }

    }
}