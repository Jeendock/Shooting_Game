using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHUD : Singleton<GameHUD>
{
    private int score;
    private Text scoreText;

    protected override void Awake()
    {
        score = 0;
        base.Awake();

        foreach (Transform childTransform in transform)
        {
            if (childTransform.gameObject.name == "ScoreText")
            {
                scoreText = childTransform.gameObject.GetComponent<Text>();
                break;
            }
        }
    }

    public void AddScore(int additionalscore)
    {
        this.score += additionalscore;
        scoreText.text = $"Score : {score}";
    }
}