using UnityEngine;
using UnityEngine.SceneManagement;

namespace Pirate.Scripts.Components {
    public class ReloadLevelComponent : MonoBehaviour {

        [SerializeField] private Bank bankCoin;

        public void Reload() {
            bankCoin._totalScore = 0;
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
            Debug.Log(bankCoin._totalScore);
        }
    }
}