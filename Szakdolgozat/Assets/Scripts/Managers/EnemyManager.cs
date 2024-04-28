using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;
    public ClassDataSo enemyData;


    void Awake()
    {
        instance = this;
        enemyData.currentHp = enemyData.maxHp;
        enemyData.currentAp = 2;
        enemyData.currentRap = enemyData.maxRap;
        enemyData.shield = 0;
        enemyData.Decker();
    }
}
