using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlchemistEquipent : Equipment
{
    CardDataSo aData;
    void Start()
    {
        aData = GetComponent<Card>().data;
        GetComponent<CardAction>().onCardPlayed += onPlayed;
    }

    public void onPlayed()
    {
        AlchemistGloves();
        PotionLauncher();
    }

    void AlchemistGloves()
    {
        if (aData.cardName != "Alchemist Gloves")
        {
            return;
        }
        GameManager.instance.firstPotionOn = true;
    }

    void PotionLauncher() 
    {
        if (aData.cardName != "Potion Launcher")
        {
            return;
        }
        BuffDamage(aData);
    }
}
