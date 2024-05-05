using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewCardManager : MonoBehaviour
{
    public static NewCardManager instance;
    [SerializeField] List<CardDataSo> cards;
    public GameObject finalize;
    public ClassDataSo hero;
    public Transform parent;
    public CardDataSo chosenCard;
    public int cardnum;

    private void Awake()
    {
        instance = this;
        if (StaticData.hero != null)
        {
            hero = StaticData.hero;
        }
    }
    void Start()
    {
        FirstRender();
    }

    void FirstRender() 
    {
        for (int i = cardnum; i < cardnum + 4; i++)
        {
            var card = Instantiate(cards[i].prefab, parent);
            card.GetComponent<Card>().data = cards[i];
            card.AddComponent<CardChoices>();
            Destroy(card.GetComponent<CardAction>());
            Destroy(card.GetComponent<CardMovement>());
        }
    }
    public void RenderCards() 
    {
        for (int i = 0; i < 4; i++)
        {
            var card = parent.GetChild(i);
            Destroy(card.gameObject);
        }
        if (cardnum >= 44)
        {
            cardnum = 40;
        }
        else if (cardnum <= 0)
        {
            cardnum = 0;
        }
        for (int i = cardnum; i < cardnum + 4; i++)
        {
            print(cards[i].cardName);
            if (cards[i].isActionCost)
            {
                cards[i].prefab.transform.Find("price").GetComponent<TextMeshPro>().text = string.Concat(cards[i].cost) + " ap";
            }
            else
            {
                cards[i].prefab.transform.Find("price").GetComponent<TextMeshPro>().text = string.Concat(cards[i].cost) + " rp";
            }
            cards[i].prefab.transform.Find("Desc").GetComponent<TextMeshPro>().text = string.Concat(cards[i].description);
            cards[i].prefab.transform.Find("dmg").GetComponent<TextMeshPro>().text = string.Concat(cards[i].dmg);
            cards[i].prefab.transform.Find("Type").GetComponent<TextMeshPro>().text = string.Concat(cards[i].cardType);
            var card = Instantiate(cards[i].prefab, parent);
            card.GetComponent<Card>().data = cards[i];
            card.AddComponent<CardChoices>();
            Destroy(card.GetComponent<CardAction>());
            Destroy(card.GetComponent<CardMovement>());
        }
    }
}
