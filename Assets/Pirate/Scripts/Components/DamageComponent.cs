using UnityEngine;

namespace Pirate.Scripts.Components {
    public class DamageComponent : MonoBehaviour {

        [SerializeField] private int damage;

        public void ApplyDamage(GameObject target) {
            var healthComponent = target.GetComponent<HealthComponent>();
            if (healthComponent != null) {
                Debug.Log("fucking damage");
                healthComponent.ApplyDamage(damage);
            }
        }

    }
}