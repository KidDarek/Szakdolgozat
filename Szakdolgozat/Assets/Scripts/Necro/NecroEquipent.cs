using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NecroEquipent : Equipment
{
    CardDataSo nData;
    void Start()
    {
        nData = GetComponent<Card>().data;
        GetComponent<CardAction>().onCardPlayed += onPlayed;
    }

    public void onPlayed()
    {
        Bob();
        Harly();
    }

    void Bob()
    {
        if (nData.cardName != "Bob")
        {
            return;
        }
        BuffDamage(nData);
    }

    void Harly()
    {
        if (nData.cardName != "Harly")
        {
            return;
        }
        BuffDamage(nData);
    }
}
