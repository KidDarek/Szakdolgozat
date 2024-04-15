using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    CardDataSo data;
    // Start is called before the first frame update
    void Start()
    {
        data = GetComponent<Card>().data;
        GetComponent<CardAction>().onCardPlayed += OnCardPlayed;
    }

    public void OnCardPlayed() 
    {
        if (data.dmgType == DamageType.Physical)
        {
            GameManager.instance.heroData.attackDmgBonus += data.dmg;
        }
        else if (data.dmgType == DamageType.Magic)
        {
            GameManager.instance.heroData.spellDmgBonus += data.dmg;
        }
    }

    private void OnDisable()
    {
        GetComponent<CardAction>().onCardPlayed -= OnCardPlayed;
    }
}
