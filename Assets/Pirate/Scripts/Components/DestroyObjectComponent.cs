using UnityEngine;

namespace Pirate.Scripts.Components {
    public class DestroyObjectComponent : MonoBehaviour {
        public void Destroy() {
            Destroy(gameObject);
        }
    }
}