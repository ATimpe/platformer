using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UICounters : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI coinText;
    [SerializeField] TextMeshProUGUI timeText;
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
        timer += Time.deltaTime;
        TimeSpan timeSpan = TimeSpan.FromSeconds(timer);
        time = 400 - timeSpan.Seconds;

        scoreText.text = "MARIO\n" + score.ToString("000000");
        coinText.text = "COINS: " + coin.ToString("00");
        timeText.text = "TIME\n" + time.ToString("000");
    }

    public void addScore(int amount) {
        score += amount;
    }

    public void addCoin(int amount) {
        coin += amount;
    }
}
