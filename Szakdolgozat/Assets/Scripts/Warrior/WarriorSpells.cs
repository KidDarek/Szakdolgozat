using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorSpells : Spell
{
    CardDataSo wData;

    void Start()
    {
        wData = GetComponent<Card>().data;
        GetComponent<CardAction>().onCardPlayed += OnWarriorCardPlayed;
    }

    void OnWarriorCardPlayed()
    {
        DoubleStrike();
        FuryStrike();
        BattleRage();
    }

    // Warior Spells
    void DoubleStrike()
    {
        if (wData.cardName != "Double Strike")
        {
            return;
        }
        for (int i = 0; i < 2; i++)
        {
            DealDamage(wData);
        }

    }

    void FuryStrike()
    {
        if (wData.cardName != "Fury Strikes")
        {
            return;
        }
        for (int i = 0; i < GameManager.instance.heroData.currentAp; i++)
        {
            DealDamage(wData);
            GameManager.instance.heroData.currentAp--;
        }
    }

    void BattleRage() 
    {
        if (wData.cardName != "Battlerage")
        {
            return;
        }
        GameManager.instance.tempAttackBonus[0] += 2;
        GameManager.instance.tempAttackBonus[1] += 2;
        GameManager.instance.heroData.attackDmgBonus += 2;
        GameManager.instance.heroData.spellDmgBonus += 2;
    }


}
