using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    List<Transform> hand;
    ClassDataSo data;
    void Start()
    {
        data = EnemyManager.instance.enemyData;
        for (int i = 0; i < transform.childCount; i++)
        {
            hand.Add(transform.GetChild(i));
        }
    }



}
