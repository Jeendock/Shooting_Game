using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class UI<T> : Singleton<T> where T : Component
{
    private readonly string UIParsingSeparator = "_";

    protected Dictionary<string, GameObject> Eliment;

    protected override void Awake()
    {
        base.Awake();

        Eliment = new Dictionary<string, GameObject>();

        foreach (var child in transform.GetComponentsInChildren<Transform>(true))
        {
            if (child.name.StartsWith(UIParsingSeparator))
            {
                Eliment.Add(child.name.Substring(1), child.gameObject);
            }
        }
    }
}