using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private GameObject Player;

    public void gameOver(bool win) {
        if (win) {
            gameOverText.text = "YOU WIN!";
            gameObject.GetComponent<UICounters>().endGame();
        } else {
            Destroy(Player);
            gameOverText.text = "GAME OVER";
        }
    }
}
