using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaladinArenaEffect : MonoBehaviour
{
    CardDataSo pData;
    void Start()
    {
        pData = GetComponent<Card>().data;
        GetComponent<CardAction>().onCardPlayed += onPlayed;
    }

    void onPlayed() 
    {
        MountainStance();

    }

    void MountainStance()
    {
        if (pData.cardName != "Mountain Stance")
        {
            return;
        }
    }
}
