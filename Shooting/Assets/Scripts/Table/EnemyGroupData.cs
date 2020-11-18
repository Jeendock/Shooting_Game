using System.Collections.Generic;
using System.Linq;
using UnityEditor;

public class EnemyGroupData : GameData<EnemyGroupData>
{
    public string Key;
    public int MinEnemyId;
    public int MaxEnemyId;
    public float Speed;

    public static void LoadData(string fileName)
    {
        LoadData(fileName, elem => elem.Key);
    }
}