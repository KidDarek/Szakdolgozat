using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpNumDisplay : MonoBehaviour
{
    ClassDataSo data;
    void Start()
    {
        data = GameManager.instance.heroData;
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
