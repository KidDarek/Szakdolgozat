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
        enemyData.maxHp = 20;
        enemyData.currentHp = enemyData.maxHp;
        enemyData.maxAp = 4;
        enemyData.maxRap = 3;
        enemyData.spellDmgBonus = 0;
        enemyData.attackDmgBonus = 0;
        enemyData.currentAp = 2;
        enemyData.currentRap = enemyData.maxRap;
        enemyData.shield = 0;
        enemyData.Decker();
    }
}
