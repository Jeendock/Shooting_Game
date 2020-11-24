using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class MainMenu : UI<MainMenu>
{
    protected override void Awake()
    {
        base.Awake();

        Eliment["GameStartButton"].GetComponent<Button>().onClick.AddListener(() =>
        {
            GameScene.Instance.StartGame();
        });

        Eliment["RankingButton"].GetComponent<Button>().onClick.AddListener(() =>
       {
           StartCoroutine(SendScore());
           StartCoroutine(getRanking());
       });
    }

    private IEnumerator SendScore()
    {
        var form = new WWWForm();
        form.AddField("name", SystemInfo.deviceName);
        form.AddField("score", 1000);

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

    private IEnumerator getRanking()
    {
        var request = UnityWebRequest.Get("http://127.0.0.1:3000/ranking");

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