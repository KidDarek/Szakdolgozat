using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangerArenaEffect : MonoBehaviour
{
    CardDataSo rData;
    void Start()
    {
        rData = GetComponent<Card>().data;
        GetComponent<CardAction>().onCardPlayed += onPlayed;
    }

    void onPlayed() 
    {
        WindSweptHills();
        HuntersTrap();

    }

    void WindSweptHills()
    {
        if (rData.cardName != "Wind Swept Hills")
        {
            return;
        }
    }

    void HuntersTrap() 
    {
        if (rData.cardName != "Hunters Trap")
        {
            return;
        }

    }
}
