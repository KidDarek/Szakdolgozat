using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaSpells : Spell
{
    CardDataSo nData;
    [SerializeField] CardDataSo token;
    int daggerDmgBonus;
    int dmg;

    void Start()
    {
        nData = GetComponent<Card>().data;
        dmg = nData.dmg;
        GetComponent<CardAction>().onCardPlayed += OnNinjaCardPlayed;
        daggerDmgBonus = 1;
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
        print(GameManager.instance.tokenDmgOn);
        if (nData.cardName != "Dagger")
        {
            return;
        }
        if (GameManager.instance.tokenDmgOn)
        {
            dmg += daggerDmgBonus;
        }
        ShieldCheck(dmg);
        dmg -= daggerDmgBonus;
    }

    void PocketDaggers()
    {
        if (nData.cardName != "Pocket Daggers")
        {
            return;
        }
        for (int i = 0; i < 3; i++)
        {
            GameManager.instance.playerDeck.CreateCard(token);
        }
    }

    void SharpDaggers() 
    {
        if (nData.cardName != "Sharp Daggers")
        {
            return;
        }
        GameManager.instance.tokenDmgOn = true;
        for (int i = 0; i < 5; i++)
        {
            GameManager.instance.playerDeck.CreateCard(token);
        }
    }


}
