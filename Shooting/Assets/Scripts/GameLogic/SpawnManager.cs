using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public int EnemyTerm = 20;
    private int enemeyTermCount = 0;

    private void Start()
    {
    }

    private void Update()
    {
        enemeyTermCount++;
        if (enemeyTermCount > EnemyTerm)
        {
            Spawn();
            enemeyTermCount = 0;
        }
    }

    private void Spawn()
    {
        var enemeyPrefap = Resources.Load("Prefab/EnemyGroup") as GameObject;
        var enemeyObject = Instantiate(enemeyPrefap);
        enemeyObject.transform.position = transform.position;
    }
}