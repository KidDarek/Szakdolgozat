using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpells : MonoBehaviour
{
    CardDataSo data;

    void Start()
    {
        data = GetComponent<Card>().data;
        GetComponent<CardAction>().onCardPlayed += OnCardPlayed;
    }

    public void OnCardPlayed()
    {
        Strike();

        Draw();

        Defend();
    }

    // Common Spells

    void Strike()
    {
        if (data.cardName != "Strike")
        {
            return;
        }
        DealDamage(data);
    }

    void Defend()
    {
        if (data.cardName != "Shield")
        {
            return;
        }
        GetShield();
    }

    void Draw()
    {
        if (data.cardName != "Draw")
        {
            return;
        }
        DrawCards();
    }

    //
    //These are the card functions
    //

    public void DealDamage(CardDataSo data)
    {
        GameManager.instance.strikeCount++;
        if (data.dmg == 0)
        {
            return;
        }
        NormalDamageCheck(data);


    }

    void NormalDamageCheck(CardDataSo data)
    {
        if (data.dmgType == DamageType.Physical)
        {
            ShieldCheck(data.dmg + EnemyManager.instance.enemyData.attackDmgBonus);
        }
        else if (data.dmgType == DamageType.Magic)
        {
            ShieldCheck(data.dmg + EnemyManager.instance.enemyData.spellDmgBonus);
        }
    }

    void ShieldCheck(int dmg)
    {
        if (GameManager.instance.heroData.shield != 0)
        {
            if (dmg < GameManager.instance.heroData.shield)
            {
                GameManager.instance.heroData.shield --;
            }
            else
            {

                GameManager.instance.heroData.currentHp -= dmg - GameManager.instance.heroData.shield;
                GameManager.instance.heroData.shield --;

            }
            return;
        }
        GameManager.instance.heroData.currentHp -= dmg;
    }

    public void DrawCards()
    {
        if (data.draws == 0)
        {
            return;
        }
        for (int i = 0; i < data.draws; i++)
        {
            EnemyManager.instance.enemyDeck.PutCardInHand();
        }
    }

    public void GetShield()
    {

        if (data.hp == 0)
        {
            return;
        }
        EnemyManager.instance.enemyData.shield += data.hp;
    }

    public void Heal()
    {
        if (!data.isHealing)
        {
            return;
        }
        EnemyManager.instance.enemyData.currentHp += data.dmg + EnemyManager.instance.enemyData.spellDmgBonus;
    }

    private void OnDisable()
    {
        GetComponent<CardAction>().onCardPlayed -= OnCardPlayed;
    }

}
