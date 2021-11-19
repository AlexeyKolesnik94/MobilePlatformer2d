using UnityEngine;

namespace Pirate.Scripts {
    public class FollowTarget : MonoBehaviour {

        [SerializeField] private Transform player;
        [SerializeField] private float damping;


        private void LateUpdate() {
            Vector3 destination = new Vector3(player.position.x, player.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, destination, Time.deltaTime * damping);
        }
    }
}