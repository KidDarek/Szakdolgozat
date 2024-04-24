using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaSpells : Spell
{
    CardDataSo nData;
    [SerializeField] CardDataSo token;
    int daggerDmgBonus = 0;

    void Start()
    {
        nData = GetComponent<Card>().data;
        GetComponent<CardAction>().onCardPlayed += OnNinjaCardPlayed;
    }

    void OnNinjaCardPlayed()
    {
        Dagger();
        PocketDaggers();
        SharpDaggers();
    }

    // Warior Spells
    void Dagger()
    {
        if (nData.cardName != "Dagger")
        {
            return;
        }
        if (GameManager.instance.tokenDmgOn)
        {
            nData.dmg += daggerDmgBonus;
        }
        DealDamage(nData);
        nData.dmg -= daggerDmgBonus;
    }

    void PocketDaggers()
    {
        if (nData.cardName != "Pocket Daggers")
        {
            return;
        }
        for (int i = 0; i < 3; i++)
        {
            GameManager.instance.playerDeck.CreateToken(token);
        }
    }

    void SharpDaggers() 
    {
        if (nData.cardName != "Sharp Daggers")
        {
            return;
        }
        GameManager.instance.tokenDmgOn = true;
        daggerDmgBonus = 1;
        for (int i = 0; i < 5; i++)
        {
            GameManager.instance.playerDeck.CreateToken(token);
        }
    }


}
