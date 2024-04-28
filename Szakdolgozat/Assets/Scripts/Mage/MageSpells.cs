using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageSpells : Spell
{
    CardDataSo vData;

    void Start()
    {
        vData = GetComponent<Card>().data;
        GetComponent<CardAction>().onCardPlayed += OnPaladinCardPlayed;
    }

    void OnPaladinCardPlayed()
    {
        ArcaneSpikes();
        MagicMissile();
    }

    // Warior Spells
    void ArcaneSpikes()
    {
        if (vData.cardName != "Arcane Spikes")
        {
            return;
        }
        for (int i = 0; i < 3 + GameManager.instance.heroData.spellDmgBonus; i++)
        {
            ShieldCheck(vData.dmg);
        }
    }

    void MagicMissile()
    {
        if (vData.cardName != "Magic Missile")
        {
            return;
        }
        ShieldCheck((vData.dmg + GameManager.instance.heroData.spellDmgBonus)*3);
    }


}
