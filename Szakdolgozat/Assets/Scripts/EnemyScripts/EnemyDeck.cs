using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeck : MonoBehaviour
{
    List<CardDataSo> deck;
    [SerializeField] Transform hand;
    List<CardDataSo> deadDeck = new();
    Quaternion flipCard;
    bool alreadyDrawn;
    public int handCount;
    // Start is called before the first frame update
    private void Awake()
    {
        flipCard = Quaternion.Euler(180,0,0);
        alreadyDrawn = false;
    }
    void Start()
    {
        deck = EnemyManager.instance.enemyData.deck;
        Utils.ShuffleList(deck);
        for (int i = 0; i < 4; i++)
        {
            PutCardInHand();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.isPlayerTurn && !alreadyDrawn)
        {
           PutCardInHand();
            alreadyDrawn = true;
        }

        if (GameManager.instance.isPlayerTurn)
        {
            alreadyDrawn = false;
        }
    }

    public void AddCardToDeck(CardDataSo data) 
    {
        deck.Add(data);
    }


    public void PutCardInHand()
    {
        if (deck.Count == 0)
        {
            return;
        }
        var data = deck[0];
        var card = Instantiate(data.prefab, hand);
        card.GetComponent<Transform>().rotation = flipCard; 
        card.GetComponent<Card>().data = data;
        Destroy(card.GetComponent<CardMovement>());
        deck.Remove(deck[0]);
    }
}
