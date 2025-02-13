using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangerSpells : Spell
{
    CardDataSo rData;

    void Start()
    {
        rData = GetComponent<Card>().data;
        GetComponent<CardAction>().onCardPlayed += OnRangerCardPlayed;
    }

    void OnRangerCardPlayed()
    {
        ArrowVolley();
    }

    // Warior Spells
    void ArrowVolley()
    {
        if (rData.cardName != "Arrow Volley")
        {
            return;
        }
        for (int i = 0; i < 4 + GameManager.instance.heroData.attackDmgBonus 
            + GameManager.instance.heroData.spellDmgBonus; i++)
        {
            ShieldCheck(1);
        }
    }
}
