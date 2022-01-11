using UnityEngine;

namespace Pirate.Scripts {
    public class Coin : MonoBehaviour {

        [SerializeField] private int coinScore;
        [SerializeField] private Bank bank;

        public void TotalScore() {
            Debug.Log(bank.TotalScore(coinScore));
        }
    }
}