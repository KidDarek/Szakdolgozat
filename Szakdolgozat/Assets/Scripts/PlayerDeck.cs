using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeck : MonoBehaviour
{
    [SerializeField] List<CardDataSo> deck;
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
        deck = new();
        deck.AddRange(deadDeck);
        deadDeck.Clear();
        Utils.ShuffleList(deck);
    }

    public void AddCardToDeadDeck(CardDataSo data) 
    {
        deadDeck.Add(data);
    }

    public void PutCardInHand()
    {
        if (deck.Count == 0)
        {
            return;
        }
        var data = deck[0];
        var card = Instantiate(data.prefab, hand);
        card.GetComponent<Card>().data = data;
        deck.Remove(deck[0]);
    }
}