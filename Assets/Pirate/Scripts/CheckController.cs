using UnityEngine;

namespace Pirate.Scripts {
    public class CheckController : MonoBehaviour {

        public bool isGround;
    
        private void OnCollisionEnter2D(Collision2D other) {
            Ground ground = other.collider.GetComponent<Ground>();
            if (!ground) return;
            isGround = true;
        }
    }
}