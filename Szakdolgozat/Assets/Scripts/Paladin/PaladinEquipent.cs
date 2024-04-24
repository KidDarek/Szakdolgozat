using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaladinEquipent : Equipment
{
    CardDataSo pData;
    void Start()
    {
        pData = GetComponent<Card>().data;
        GetComponent<CardAction>().onCardPlayed += onPlayed;
    }

    public void onPlayed()
    {
        PaladinShield();
    }

    void PaladinShield()
    {
        if (pData.cardName != "Paladin Shield")
        {
            return;
        }
    }
}
