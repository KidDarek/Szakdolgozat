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
    private void Update()
    {
        if (NewCardManager.instance.chosenCard != data)
        {
            transform.Find("color").GetComponent<SpriteRenderer>().color = GetComponent<Card>().data.prefab.transform.Find("color").GetComponent<SpriteRenderer>().color;
        }
    }

    private void OnMouseUpAsButton()
    {
        transform.Find("color").GetComponent<SpriteRenderer>().color = Color.yellow;
        Color tmp = transform.Find("color").GetComponent<SpriteRenderer>().color;
        tmp.a = 0.8f;
        transform.Find("color").GetComponent<SpriteRenderer>().color = tmp;
        NewCardManager.instance.chosenCard = data;
        finalize.SetActive(true);
    }
}
