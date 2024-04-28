using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageArenaEffect : MonoBehaviour
{
    CardDataSo vData;
    void Start()
    {
        vData = GetComponent<Card>().data;
        GetComponent<CardAction>().onCardPlayed += onPlayed;
    }

    void onPlayed() 
    {
        TheStorm();

    }

    void TheStorm()
    {
        if (vData.cardName != "The Storm")
        {
            return;
        }
    }
}
