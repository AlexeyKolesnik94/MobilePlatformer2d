using UnityEngine;

namespace Pirate.Scripts {
    public class Bank : MonoBehaviour {

        public int _totalScore;

        public int TotalScore(int coin) {
            return _totalScore += coin;
        }
    }
}