using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NecroSpells : Spell
{
    CardDataSo nData;

    void Start()
    {
        nData = GetComponent<Card>().data;
        GetComponent<CardAction>().onCardPlayed += OnNecroCardPlayed;
    }

    void OnNecroCardPlayed()
    {
        ForbiddenKnowledge();
        DecayingTouch();
    }

    // Warior Spells
    void ForbiddenKnowledge()
    {
        if (nData.cardName != "Forbidden Knowledge")
        {
            return;
        }
        GameManager.instance.heroData.currentHp -= 2;
        for (int i = 0; i < 2; i++)
        {
            GameManager.instance.playerDeck.PutCardInHand();
        }
    }

    void DecayingTouch()
    {
        if (nData.cardName != "Decaying Touch")
        {
            return;
        }
        ShieldCheck(2 + GameManager.instance.heroData.spellDmgBonus);
        Heal(nData);
    }


}
