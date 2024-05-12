using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaEquipent : Equipment
{
    CardDataSo nData;
    // Start is called before the first frame update
    void Start()
    {
        nData = GetComponent<Card>().data;
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
        if (nData.cardName != "Kunai")
        {
            return;
        }
        BuffDamage(nData);
    }

    void Kyoketsu()
    {
        if (nData.cardName != "Kyoketsu-smoge")
        {
            return;
        }
        BuffDamage(nData);
    }
    void WeaponThrow() 
    {
        if (nData.cardName != "Weapon Throw")
        {
            return;
        }
        GetComponent<Spell>().DealDamage(nData);
        transform.Find("color").GetComponent<SpriteRenderer>().color = Color.white;
        GetComponent<SpriteRenderer>().color = Color.white;
        Color tmp = GetComponent<SpriteRenderer>().color;
        tmp.a = 1f;
        transform.Find("color").GetComponent<SpriteRenderer>().color = tmp;
    }
}
