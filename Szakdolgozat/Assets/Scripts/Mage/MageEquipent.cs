using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageEquipent : Equipment
{
    CardDataSo vData;
    void Start()
    {
        vData = GetComponent<Card>().data;
        GetComponent<CardAction>().onCardPlayed += onPlayed;
    }

    public void onPlayed()
    {
        SorcefullStaff();
        ArcaneSpellbook();
    }

    void SorcefullStaff()
    {
        if (vData.cardName != "Sorcefull Staff")
        {
            return;
        }
        BuffDamage(vData);
    }

    void ArcaneSpellbook() 
    {
        if (vData.cardName != "Arcane Spellbook")
        {
            return;
        }
        BuffDamage(vData);
    }
}
