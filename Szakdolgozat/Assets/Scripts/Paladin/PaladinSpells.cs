using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaladnSpells : Spell
{
    CardDataSo pData;

    void Start()
    {
        pData = GetComponent<Card>().data;
        GetComponent<CardAction>().onCardPlayed += OnPaladinCardPlayed;
    }

    void OnPaladinCardPlayed()
    {
        Provoke();
        HolyBlock();
        ShieldThrow();
    }

    // Warior Spells
    void Provoke()
    {
        if (pData.cardName != "Provoke")
        {
            return;
        }
        GameManager.instance.heroData.shield++;
        GameManager.instance.playerDeck.PutCardInHand();
    }

    void HolyBlock()
    {
        if (pData.cardName != "Holy Block")
        {
            return;
        }
        GameManager.instance.heroData.shield += 5;
        GameManager.instance.tempAttackBonus[1] += pData.dmg;
    }

    void ShieldThrow() 
    {
        if (pData.cardName != "Shield Throw")
        {
            return;
        }
        pData.dmg += GameManager.instance.heroData.shield;
        ShieldCheck(pData.dmg);
        pData.dmg -= GameManager.instance.heroData.shield;
    }


}
