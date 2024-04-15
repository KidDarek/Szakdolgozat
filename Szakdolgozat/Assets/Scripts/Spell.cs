using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
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
        DealDamage();

        DrawCards();

        GetShield();

    }
    void DealDamage()
    {
        if (data.dmg == 0)
        {
            return;
        }
        if (data.dmgType == DamageType.Physical)
        {
            EnemyManager.instance.enemyData.currentHp -= data.dmg + GameManager.instance.heroData.attackDmgBonus;
        }
        else if (data.dmgType == DamageType.Magic)
        {
            EnemyManager.instance.enemyData.currentHp -= data.dmg + GameManager.instance.heroData.spellDmgBonus;
        }

    }

    public void DrawCards()
    {
        if (data.draws == 0)
        {
            return;
        }
        for (int i = 0; i < data.draws; i++)
        {
            GameManager.instance.playerDeck.PutCardInHand();
        }
    }

    void GetShield()
    {

        if (data.hp == 0)
        {
            return;
        }
        GameManager.instance.heroData.shield += data.hp;
    }

    private void OnDisable()
    {
        GetComponent<CardAction>().onCardPlayed -= OnCardPlayed;
    }
}
