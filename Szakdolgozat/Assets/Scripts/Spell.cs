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
        GameManager.instance.strikeCount++;
        DealDamage(data);
    }

    void Defend()
    {
        if (data.cardName != "Defend")
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
        if (IsBobDown())
        {
            ShieldCheck(2);
        }
        if (IsHarlyDown())
        {
            ShieldCheck(2);
        }


    }

    void NormalDamageCheck(CardDataSo data)
    {
        if (IsSorcefullDown())
        {
            ShieldCheck(data.dmg + GameManager.instance.heroData.attackDmgBonus 
                + GameManager.instance.heroData.spellDmgBonus);
        }
        else if (data.dmgType == DamageType.Physical)
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

    public void ShieldCheck(int dmg)
    {
        int shieldDmg = GameManager.instance.shieldDmg;
        if (EnemyManager.instance.enemyData.shield != 0)
        {
            if (dmg + shieldDmg <= EnemyManager.instance.enemyData.shield)
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
        if (IsStromDown())
        {
            EnemyManager.instance.enemyData.currentHp--;
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

    public void GetShield()
    {

        if (data.hp == 0)
        {
            return;
        }
        GameManager.instance.heroData.shield += data.hp;
    }

    public void Heal(CardDataSo data)
    {
        if (!data.isHealing)
        {
            return;
        }
        GameManager.instance.heroData.RestoreHealth(data.dmg + GameManager.instance.heroData.spellDmgBonus);
    }

    bool IsSorcefullDown()
    {
        var board = GameManager.instance.cardsOnBoard;
        bool isDown = false;
        for (int i = 0; i < board.Count; i++)
        {
            if (board[i].GetComponent<Card>().data.cardName == "Sorcefull Staff")
            {
                isDown = true;
            }
        }
        return isDown;
    }

    bool IsStromDown()
    {
        var board = GameManager.instance.cardsOnBoard;
        bool isDown = false;
        for (int i = 0; i < board.Count; i++)
        {
            if (board[i].GetComponent<Card>().data.cardName == "The Storm")
            {
                isDown = true;
            }
        }
        return isDown;
    }
    bool IsBobDown()
    {
        var board = GameManager.instance.cardsOnBoard;
        bool isDown = false;
        for (int i = 0; i < board.Count; i++)
        {
            if (board[i].GetComponent<Card>().data.cardName == "Bob")
            {
                isDown = true;
            }
        }
        return isDown;
    }

    bool IsHarlyDown()
    {
        var board = GameManager.instance.cardsOnBoard;
        bool isDown = false;
        for (int i = 0; i < board.Count; i++)
        {
            if (board[i].GetComponent<Card>().data.cardName == "Harly")
            {
                isDown = true;
            }
        }
        return isDown;
    }

    private void OnDisable()
    {
        GetComponent<CardAction>().onCardPlayed -= OnCardPlayed;
    }


}
