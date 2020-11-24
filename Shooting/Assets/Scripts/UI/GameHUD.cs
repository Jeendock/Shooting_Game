using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHUD : UI<GameHUD>
{
    public int Score { get; private set; }

    protected override void Awake()
    {
        Score = 0;
        base.Awake();
    }

    public void AddScore(int additionalscore)
    {
        this.Score += additionalscore;
        Eliment["ScoreText"].GetComponent<Text>().text = $"Score : {Score}";
    }
}