using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
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
        if (data.cardType == CardTypes.Token)
        {
            TokenDamageCheck(data);
            return;
        }
        NormalDamageCheck(data);


    }

    void NormalDamageCheck(CardDataSo data) 
    {
        if (data.dmgType == DamageType.Physical)
        {
            ShieldCheck(data.dmg + GameManager.instance.heroData.attackDmgBonus);
        }
        else if (data.dmgType == DamageType.Magic)
        {
            ShieldCheck(data.dmg + GameManager.instance.heroData.spellDmgBonus);
        }
    }

    void TokenDamageCheck(CardDataSo data)
    {
        if (data.dmgType == DamageType.Physical)
        {
            ShieldCheck(data.dmg);
        }
        else if (data.dmgType == DamageType.Magic)
        {
            ShieldCheck(data.dmg);
        }
    }

    void ShieldCheck(int dmg) 
    {
        int shieldDmg = GameManager.instance.shieldDmg;
        if (EnemyManager.instance.enemyData.shield != 0)
        {
            if (dmg + shieldDmg < EnemyManager.instance.enemyData.shield)
            {
                EnemyManager.instance.enemyData.shield -= shieldDmg;
            }
            else
            {
                bool fleshRipperOn = false;
                for (int i = 0; i < GameManager.instance.cardsOnBoard.Count; i++)
                {
                    if (GameManager.instance.cardsOnBoard[i].GetComponent<Card>().data.cardName == "Flesh Ripper")
                    {
                        fleshRipperOn = true;
                    }
                }
                if (fleshRipperOn)
                {
                    EnemyManager.instance.enemyData.shield -= shieldDmg;
                    EnemyManager.instance.enemyData.currentHp -= dmg - EnemyManager.instance.enemyData.shield;
                }
                else
                {
                    EnemyManager.instance.enemyData.currentHp -= dmg - EnemyManager.instance.enemyData.shield;
                    EnemyManager.instance.enemyData.shield -= shieldDmg;
                }
            }
            return;
        }
        EnemyManager.instance.enemyData.currentHp -= dmg;
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

    public void GetShield()
    {

        if (data.hp == 0)
        {
            return;
        }
        GameManager.instance.heroData.shield += data.hp;
    }

    public void Heal()
    {
        if (!data.isHealing)
        {
            return;
        }
        GameManager.instance.heroData.currentHp += data.dmg + GameManager.instance.heroData.spellDmgBonus;
    }

    private void OnDisable()
    {
        GetComponent<CardAction>().onCardPlayed -= OnCardPlayed;
    }


}
