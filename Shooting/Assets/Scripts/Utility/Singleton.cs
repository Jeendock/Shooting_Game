using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : Component
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                var foundObject = FindObjectsOfType(typeof(T)) as T[];
                if (foundObject.Length >= 2)
                {
                    foreach (var found in foundObject)
                        Debug.LogError($"gmaeObject name: {found.name}");

                    throw new System.Exception($"{typeof(T).ToString()} is duplicated. ");
                }
                if (foundObject.Length > 0)
                {
                    instance = foundObject[0];
                }

                if (instance == null)
                {
                    var newGameObject = new GameObject("GameScene");
                    instance = newGameObject.AddComponent<T>();
                }
            }
            return instance;
        }
    }

    protected virtual void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}