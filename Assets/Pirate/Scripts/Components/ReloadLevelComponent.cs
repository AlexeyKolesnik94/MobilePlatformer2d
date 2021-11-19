using UnityEngine;
using UnityEngine.SceneManagement;

namespace Pirate.Scripts.Components {
    public class ReloadLevelComponent : MonoBehaviour {

        public void Reload() {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
        
    }
}