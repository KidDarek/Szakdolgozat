using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class furyAttack : MonoBehaviour
{
    [SerializeField] CardDataSo wData;
    void Start()
    {
    }

    void Update()
    {
        wData.cost = GameManager.instance.heroData.currentAp;
        GetComponent<TextMeshPro>().text = string.Concat(wData.cost + " ap");
    }
}
