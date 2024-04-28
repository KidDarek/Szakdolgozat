using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NecroArenaEffect : MonoBehaviour
{
    CardDataSo nData;
    void Start()
    {
        nData = GetComponent<Card>().data;
        GetComponent<CardAction>().onCardPlayed += onPlayed;
    }

    void onPlayed() 
    {
        TheGraveyard();

    }

    void TheGraveyard()
    {
        if (nData.cardName != "The Graveyard")
        {
            return;
        }
    }
}
