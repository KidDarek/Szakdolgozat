using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerDeck : MonoBehaviour
{
    List<CardDataSo> deck;
    [SerializeField] Transform hand;
    List<CardDataSo> deadDeck = new();
    bool alreadyDrawn;
    // Start is called before the first frame update
    private void Awake()
    {
        alreadyDrawn = false;
    }
    void Start()
    {
        deck = GameManager.instance.heroData.deck;
        Utils.ShuffleList(deck);
        for (int i = 0; i < 4; i++)
        {
            PutCardInHand();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (deck.Count == 0 && deadDeck.Count != 0)
        {
            RemakeDeck();
        }

        if (GameManager.instance.isPlayerTurn && !alreadyDrawn)
        {
            PutCardInHand();
            alreadyDrawn = true;
        }

        if (!GameManager.instance.isPlayerTurn)
        {
            alreadyDrawn = false;
        }
    }

    void RemakeDeck() 
    {
        for (int i = 0; i < deadDeck.Count; i++)
        {
            deck.Add(deadDeck[i]);
        }
        deadDeck.Clear();
        Utils.ShuffleList(deck);
    }

    public void AddCardToDeadDeck(CardDataSo data) 
    {
        deadDeck.Add(data);
    }

    public void PutCardInHand()
    {
        if (deck.Count == 0 || hand.childCount >= 10)
        {
            return;
        }
        var data = deck[0];
        if (data.isActionCost)
        {
            data.prefab.transform.Find("price").GetComponent<TextMeshPro>().text = string.Concat(data.cost) + " ap";
        }
        else
        {
            data.prefab.transform.Find("price").GetComponent<TextMeshPro>().text = string.Concat(data.cost) + " rp";
        }
        data.prefab.transform.Find("Desc").GetComponent<TextMeshPro>().text = string.Concat(data.description);
        data.prefab.transform.Find("dmg").GetComponent<TextMeshPro>().text = string.Concat(data.dmg);
        data.prefab.transform.Find("Type").GetComponent<TextMeshPro>().text = string.Concat(data.cardType);
        var card = Instantiate(data.prefab, hand);
        card.GetComponent<Card>().data = data;
        deck.Remove(deck[0]);
    }

    public void CreateCard(CardDataSo data) 
    {
        if (hand.childCount >= 10)
        {
            return;
        }
        if (data.isActionCost)
        {
            data.prefab.transform.Find("price").GetComponent<TextMeshPro>().text = string.Concat(data.cost) + " ap";
        }
        else
        {
            data.prefab.transform.Find("price").GetComponent<TextMeshPro>().text = string.Concat(data.cost) + " rp";
        }
        data.prefab.transform.Find("Desc").GetComponent<TextMeshPro>().text = string.Concat(data.description);
        data.prefab.transform.Find("dmg").GetComponent<TextMeshPro>().text = string.Concat(data.dmg);
        data.prefab.transform.Find("Type").GetComponent<TextMeshPro>().text = string.Concat(data.cardType);
        var card = Instantiate(data.prefab, hand);
        card.GetComponent<Card>().data = data;
    }
}
