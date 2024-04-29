using System.Collections;
using System.Collections.Generic;
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
