using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyHpNumDisplay : MonoBehaviour
{
    ClassDataSo data;
    void Start()
    {
        data = EnemyManager.instance.enemyData;
    }

    void Update()
    {
        renderHp();
    }

    void renderHp() 
    {
        GetComponent<TextMeshPro>().text = string.Concat(data.currentHp + "/" + data.maxHp);
    }
}
