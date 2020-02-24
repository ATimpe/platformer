using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UICounters : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private GameObject GameManager;
    [SerializeField] private int timeStart;
    public bool gameIsRunning = true;
    private int score, coin, time;
    static float timer;

    // Start is called before the first frame update
    void Start()
    {
        score = coin = time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameIsRunning)
            timer += Time.deltaTime;
        TimeSpan timeSpan = TimeSpan.FromSeconds(timer);
        time = timeStart - (timeSpan.Seconds + timeSpan.Minutes * 60);

        scoreText.text = "MARIO\n" + score.ToString("000000");
        coinText.text = "COINS: " + coin.ToString("00");
        timeText.text = "TIME\n" + time.ToString("000");

        if (time <= 0 && gameIsRunning) {
            GameManager.GetComponent<GameManager>().gameOver(false);
            gameIsRunning = false;
        }
    }

    public void addScore(int amount) {
        score += amount;
    }

    public void addCoin(int amount) {
        coin += amount;
    }

    public void endGame() {
        gameIsRunning = false;
    }
}
