using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DruidSpells : Spell
{
    CardDataSo dData;

    void Start()
    {
        dData = GetComponent<Card>().data;
        GetComponent<CardAction>().onCardPlayed += OnDruidCardPlayed;
    }

    void OnDruidCardPlayed()
    {
        WoodlandMending();
        Meditation();
    }

    // Warior Spells
    void WoodlandMending()
    {
        if (dData.cardName != "Woodland Mending")
        {
            return;
        }
        Heal(dData);
    }
    void Meditation()
    {
        if (dData.cardName != "Meditation")
        {
            return;
        }
        GameManager.instance.playerDeck.PutCardInHand();
        GameManager.instance.meditationOn = true;
    }
}
