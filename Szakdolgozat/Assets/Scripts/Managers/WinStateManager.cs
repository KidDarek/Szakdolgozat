using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinStateManager : MonoBehaviour
{
    ClassDataSo hero;
    ClassDataSo enemy;
    [SerializeField] GameObject winScreen;
    [SerializeField] GameObject loseScreen;
    private void Start()
    {
        hero = GameManager.instance.heroData;
        enemy = EnemyManager.instance.enemyData;
    }
    void Update()
    {
        if (hero.currentHp <= 0)
        {
            loseScreen.SetActive(true);
        }
        else if (enemy.currentHp <= 0)
        {
            winScreen.SetActive(true);
        }
    }
}