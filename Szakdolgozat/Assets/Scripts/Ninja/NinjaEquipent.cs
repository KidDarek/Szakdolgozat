using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaEquipent : Equipment
{
    CardDataSo ndata;
    // Start is called before the first frame update
    void Start()
    {
        ndata = GetComponent<Card>().data;
        GetComponent<CardAction>().onCardPlayed += onPlayed;
    }

    public void onPlayed()
    {
        Kunai();
        Kyoketsu();
        WeaponThrow();
    }

    void Kunai()
    {
        if (ndata.cardName != "Kunai")
        {
            return;
        }
        BuffDamage(ndata);
    }

    void Kyoketsu()
    {
        if (ndata.cardName != "Kyoketsu-smoge")
        {
            return;
        }
        BuffDamage(ndata);
    }
    void WeaponThrow() 
    {
        GetComponent<Spell>().DealDamage(ndata);
    }
}
