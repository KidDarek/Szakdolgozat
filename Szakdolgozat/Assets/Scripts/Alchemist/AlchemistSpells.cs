using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlchemistSpells : Spell
{
    CardDataSo aData;
    ClassDataSo hero;

    void Start()
    {
        aData = GetComponent<Card>().data;
        hero = GameManager.instance.heroData;
        GetComponent<CardAction>().onCardPlayed += OnPaladinCardPlayed;
    }

    void OnPaladinCardPlayed()
    {
        HomeBrewing();
        PotionPotion();
        Recycling();
        Acid();
        Fire();
        Health();
        Energy();
        Air();
    }

    // Warior Spells
    void HomeBrewing()
    {
        if (aData.cardName != "Home Brewing")
        {
            return;
        }
        for (int i = 0; i < 2; i++)
        {
            GameManager.instance.CreatePotion();
        }
    }

    void PotionPotion()
    {
        if (aData.cardName != "Potion Potion")
        {
            return;
        }
        for (int i = 1; i < 6; i++)
        {
            GameManager.instance.playerDeck.CreateCard(GameManager.instance.tokens[i]);
        }
    }

    void Recycling()
    {
        if (aData.cardName != "Recycling")
        {
            return;
        }
        GameManager.instance.playerDeck.PutCardInHand();
        GameManager.instance.CreatePotion();

    }

    void Acid()
    {
        if (aData.cardName != "Acid")
        {
            return;
        }
        EnemyManager.instance.enemyData.shield -= aData.dmg;
    }
    void Fire()
    {
        if (aData.cardName != "Fire")
        {
            return;
        }
        DealDamage(aData);
    }
    void Health()
    {
        if (aData.cardName != "Health")
        {
            return;
        }
        hero.RestoreHealth(aData.dmg);
    }
    void Energy()
    {
        if (aData.cardName != "Energy")
        {
            return;
        }
        hero.currentAp++;
    }
    void Air()
    {
        if (aData.cardName != "Air")
        {
            return;
        }
        GameManager.instance.playerDeck.PutCardInHand();
    }

}
