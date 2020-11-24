using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GameScene : Singleton<GameScene>
{
    public bool IsGameStart { get; private set; }

    [SerializeField]
    private SpawnManager spawnManager;

    protected override void Awake()
    {
        base.Awake();
        TableLoader.LoadAllData();
        Debug.Log("이이잉 : " + EnemyData.Get(1).Key);

        SetPlayCompoenent(false);
    }

    public void StartGame()
    {
        MainMenu.Instance.gameObject.SetActive(false);

        var playerPrefab = Resources.Load("Prefab/Player") as GameObject;
        var playerObject = Instantiate(playerPrefab);
        playerObject.GetComponent<Player>().enabled = false;

        var playerSequence = DOTween.Sequence();
        playerSequence.Append(playerObject.transform.DOMoveY(-3f, 1f));
        playerSequence.AppendCallback(() =>
        {
            IsGameStart = true;
            playerObject.GetComponent<Player>().enabled = true;
            SetPlayCompoenent(true);
        });
    }

    public void GameOver()
    {
        StartCoroutine(SendScore());
        IsGameStart = false;
        SetPlayCompoenent(false);
    }

    private void SetPlayCompoenent(bool isOn)
    {
        spawnManager.enabled = isOn;
        GameHUD.Instance.gameObject.SetActive(isOn);
        MainMenu.Instance.gameObject.SetActive(!isOn);
    }

    private IEnumerator SendScore()
    {
        var form = new WWWForm();
        form.AddField("name", SystemInfo.deviceName);
        form.AddField("score", GameHUD.Instance.Score);

        var request = UnityWebRequest.Post("http://127.0.0.1:3000/registerScore", form);

        yield return request.SendWebRequest();

        if (request.isNetworkError)
        {
            Debug.Log(request.error);
        }
        else
        {
            Debug.Log("<get>" + request.downloadHandler.text + "</get>");
        }
    }
}