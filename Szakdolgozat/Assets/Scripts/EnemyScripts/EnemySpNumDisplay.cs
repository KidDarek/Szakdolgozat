using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemySpNumDisplay : MonoBehaviour
{
    ClassDataSo data;
    void Start()
    {
        data = EnemyManager.instance.enemyData;
    }

    void Update()
    {
        renderSp();
    }

    void renderSp() 
    {
        GetComponent<TextMeshPro>().text = string.Concat(data.shield + "/" + data.maxHp);
    }
}
