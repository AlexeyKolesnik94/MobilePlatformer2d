using UnityEngine;

namespace Pirate.Scripts {
    public class Coin : MonoBehaviour {

        [SerializeField] private int coinScore;
        [SerializeField] private Bank bank;

        public void TotalScore() {
            bank.totalScore += coinScore;
            Debug.Log(bank.totalScore.ToString());
        }
        
    }
}