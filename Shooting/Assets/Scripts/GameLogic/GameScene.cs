using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScene : Singleton<GameScene>
{
    public bool IsGameStart { get; private set; }

    [SerializeField]
    private SpawnManager spawnManager;

    [SerializeField]
    private Player player;

    protected override void Awake()
    {
        base.Awake();
        TableLoader.LoadAllData();

        Debug.Log("이이잉 : " + EnemyData.Get(1).Key);

        SetPlayCompoenent(false);
    }

    public void StartGame()
    {
        var playerSequence = DOTween.Sequence();
        playerSequence.Append(player.transform.DOMoveY(-4f, 1f));
        playerSequence.AppendCallback(() =>
        {
            IsGameStart = true;
            SetPlayCompoenent(true);
        });
    }

    public void GameOver()
    {
        IsGameStart = false;

        SetPlayCompoenent(false);
    }

    private void SetPlayCompoenent(bool isOn)
    {
        spawnManager.enabled = isOn;
        player.enabled = isOn;
        GameHUD.Instance.gameObject.SetActive(isOn);
    }
}