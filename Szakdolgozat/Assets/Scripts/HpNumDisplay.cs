using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HpNumDisplay : MonoBehaviour
{
    ClassDataSo data;
    void Start()
    {
        data = GameManager.instance.heroData;
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
