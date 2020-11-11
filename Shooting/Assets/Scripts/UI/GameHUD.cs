using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHUD : UI<GameHUD>
{
    private int score;
    private Text scoreText;

    protected override void Awake()
    {
        score = 0;
        base.Awake();
    }

    public void AddScore(int additionalscore)
    {
        this.score += additionalscore;
        Eliment["ScoreText"].GetComponent<Text>().text = $"Score : {score}";
    }
}