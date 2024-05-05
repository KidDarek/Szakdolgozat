using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CardChoices : MonoBehaviour
{
    CardDataSo data;
    GameObject finalize;
    void Start()
    {
        data = GetComponent<Card>().data;
        finalize = NewCardManager.instance.finalize;
    }
    private void Update()
    {
        if (NewCardManager.instance.chosenCard != data)
        {
            GetComponent<SpriteRenderer>().color = GetComponent<Card>().data.prefab.GetComponent<SpriteRenderer>().color;
        }
    }

    private void OnMouseUpAsButton()
    {
        GetComponent<SpriteRenderer>().color = Color.yellow;
        Color tmp = GetComponent<SpriteRenderer>().color;
        tmp.a = 0.2f;
        GetComponent<SpriteRenderer>().color = tmp;
        NewCardManager.instance.chosenCard = data;
        finalize.SetActive(true);
    }
}
