using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaladinSpells : Spell
{
    CardDataSo pData;

    void Start()
    {
        pData = GetComponent<Card>().data;
        GetComponent<CardAction>().onCardPlayed += OnNinjaCardPlayed;
    }

    void OnNinjaCardPlayed()
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
        GameManager.instance.tempAttackBonus[1] += 2;
    }

    void ShieldThrow() 
    {
        if (pData.cardName != "Shieldthrow")
        {
            return;
        }
        pData.dmg += GameManager.instance.heroData.shield;
        DealDamage(pData);
        pData.dmg -= GameManager.instance.heroData.shield;
    }


}
