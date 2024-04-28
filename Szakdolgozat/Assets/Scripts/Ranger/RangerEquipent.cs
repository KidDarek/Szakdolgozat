using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangerEquipent : Equipment
{
    CardDataSo rData;
    void Start()
    {
        rData = GetComponent<Card>().data;
        GetComponent<CardAction>().onCardPlayed += onPlayed;
    }

    public void onPlayed()
    {
        RangerBow();
        Crossbow();
    }

    void RangerBow()
    {
        if (rData.cardName != "Ranger Bow")
        {
            return;
        }
        BuffDamage(rData);
    }

    void Crossbow() 
    {
        if (rData.cardName != "Crossbow")
        {
            return;
        }
        BuffDamage(rData);
    }
}
