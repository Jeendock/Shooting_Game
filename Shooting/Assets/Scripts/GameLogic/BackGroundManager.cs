using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class BackGroundManager : MonoBehaviour
{
    public List<GameObject> BackgroundSprites;
    public float BackgroundSpeed = 0.02f;

    private float ScrollPoint;

    private void Start()
    {
        ScrollPoint = BackgroundSprites[3].transform.position.y;

        var spriteHeight = BackgroundSprites[0].GetComponent<SpriteRenderer>().bounds.size.y;

        for (int i = 1; i < BackgroundSprites.Count; i++)
        {
            var prevBack = BackgroundSprites[i - 1];
            var curBack = BackgroundSprites[i];
            curBack.transform.position = new Vector2(0, prevBack.transform.position.y + spriteHeight);
        }
    }

    private void Update()
    {
        for (int i = 0; i < BackgroundSprites.Count; i++)
        {
            var CurBack = BackgroundSprites[i];

            if (CurBack.transform.position.y < -9.0f)
            {
                CurBack.transform.position = new Vector2(0, ScrollPoint);
            }

            CurBack.transform.position = new Vector2(0, CurBack.transform.position.y - BackgroundSpeed);
        }
    }
}