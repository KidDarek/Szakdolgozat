using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DruidEquipent : Equipment
{
    CardDataSo dData;
    void Start()
    {
        dData = GetComponent<Card>().data;
        GetComponent<CardAction>().onCardPlayed += onPlayed;
    }

    public void onPlayed()
    {
        DruidStaff();
    }

    void DruidStaff()
    {
        if (dData.cardName != "Druid Staff")
        {
            return;
        }
        BuffDamage(dData);
    }

}
