using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DruidArenaEffect : MonoBehaviour
{
    CardDataSo dData;
    void Start()
    {
        dData = GetComponent<Card>().data;
        GetComponent<CardAction>().onCardPlayed += onPlayed;
    }

    void onPlayed() 
    {
        VisousVeins();
        ForestOfFavours();

    }

    void VisousVeins()
    {
        if (dData.cardName != "Visous Veins")
        {
            return;
        }
    }

    void ForestOfFavours() 
    {
        if (dData.cardName != "Forest Of Favours")
        {
            return;
        }

    }
}
