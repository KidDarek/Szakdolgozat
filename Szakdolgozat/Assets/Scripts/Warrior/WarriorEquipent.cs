using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorEquipent : Equipment
{
    CardDataSo wdata;
    // Start is called before the first frame update
    void Start()
    {
        wdata = GetComponent<Card>().data;
        GetComponent<CardAction>().onCardPlayed += onPlayed;
    }

    public void onPlayed()
    {
        BloodThirster();
        FleshRipper();
    }

    void BloodThirster()
    {
        if (wdata.cardName != "Blood Thirster")
        {
            return;
        }
        wdata.dmg = GameManager.instance.strikeCount + 1;
        BuffDamage(wdata);
    }

    void FleshRipper()
    {
        if (wdata.cardName != "Flesh Ripper")
        {
            return;
        }
        GameManager.instance.shieldDmg = 2;
    }
}
