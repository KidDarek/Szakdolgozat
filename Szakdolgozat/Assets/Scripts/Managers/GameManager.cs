using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public ClassDataSo heroData;
    public List<GameObject> cardsOnBoard;
    public PlayerDeck playerDeck;
    public bool isPlayerTurn;
    public int[] tempAttackBonus = {0,0};
    public int strikeCount = 0;
    public int shieldDmg = 1;
    public List<CardDataSo> tokens;
    public bool tokenDmgOn;
    public bool meditationOn;
    public bool firstPotionOn;

    int startingAp = 3;
    void Awake()
    {
        instance = this;
        if (StaticData.hero != null)
        {
            heroData = StaticData.hero;
        }
        heroData.currentAp = startingAp;
        heroData.currentRap = heroData.maxRap;
        heroData.currentHp = heroData.maxHp;
        heroData.shield = 0;
        heroData.attackDmgBonus = 0;
        heroData.spellDmgBonus = 0;
        tokenDmgOn = false;
        meditationOn = false;
        firstPotionOn = false;
    }
    public void SpendActionOrReaction() 
    {
        var data = MovementManager.instance.selectedCard.GetComponent<Card>().data;
        if (data.isActionCost)
        {
            heroData.currentAp -= data.cost;
        }
        else
        {
            heroData.currentRap -= data.cost;
        }
    }

    public bool IsCardPlayable(CardDataSo data)
    {
        if (data.isActionCost)
        {
            return heroData.currentAp >= data.cost;
        }
        else
        {
            return heroData.currentRap >= data.cost;
        }
    }

    public void ResetTempAttack() 
    {
        tempAttackBonus[0] = 0;
        tempAttackBonus[1] = 0;
    }

    public void StartTurnEffect() 
    {
        for (int i = 0; i < cardsOnBoard.Count; i++)
        {
            if (cardsOnBoard[i].GetComponent<Card>().data.cardName == "Kunai")
            {
                playerDeck.CreateCard(tokens[0]);
            }
            if (cardsOnBoard[i].GetComponent<Card>().data.cardName == "Paladin Shield")
            {
                heroData.shield++;
            }
            if (cardsOnBoard[i].GetComponent<Card>().data.cardName == "Crossbow")
            {
                heroData.currentAp++;
            }
            if (cardsOnBoard[i].GetComponent<Card>().data.cardName == "Wind Swept Hills")
            {
                playerDeck.PutCardInHand();
            }
            if (cardsOnBoard[i].GetComponent<Card>().data.cardName == "Druid Staff")
            {
                heroData.RestoreHealth(1 + heroData.spellDmgBonus);
            }
            if (cardsOnBoard[i].GetComponent<Card>().data.cardName == "Forest Of Favours")
            {
                heroData.currentAp++;
                heroData.RestoreHealth(1 + heroData.spellDmgBonus);
            }
            if (meditationOn)
            {
                heroData.currentAp += 2;
                tempAttackBonus[1] += 3;
                heroData.spellDmgBonus += 3;
                meditationOn = false;
            }
            if (cardsOnBoard[i].GetComponent<Card>().data.cardName == "Alchemist Gloves")
            {
                CreatePotion();
                firstPotionOn = true;
            }
            if (cardsOnBoard[i].GetComponent<Card>().data.cardName == "Potion Launcher")
            {
                for (int j = 0; j < 3; j++)
                {
                    System.Random rnd = new System.Random();
                    int tokenNum = rnd.Next(1, 6);
                    switch (tokenNum)
                    {
                        case 1:
                            EnemyManager.instance.enemyData.shield--;
                            break;
                        case 2:
                            DmgCheck(1);
                            break;
                        case 3:
                            heroData.currentHp++;
                            break;
                        case 4:
                            heroData.currentAp++;
                            break;
                        case 5:
                            playerDeck.PutCardInHand();
                            break;
                        default:
                            break;
                    }
                }
            }

        }
    }

    public void EndTurnEffect() 
    {
        for (int i = 0; i < cardsOnBoard.Count; i++)
        {
            if (cardsOnBoard[i].GetComponent<Card>().data.cardName == "Kyoketsu-smoge")
            {
                GameManager.instance.strikeCount++;
                DmgCheck(strikeCount);
            }
            if (cardsOnBoard[i].GetComponent<Card>().data.cardName == "Visous Veins")
            {
                EnemyManager.instance.enemyData.currentAp--;
            }
            if (cardsOnBoard[i].GetComponent<Card>().data.cardName == "The Graveyard")
            {
                heroData.shield += 2;
            }
        }
        tokenDmgOn = false;
    }
    public void DmgCheck(int dmg)
    {
        if (EnemyManager.instance.enemyData.shield != 0)
        {
            if (dmg + shieldDmg < EnemyManager.instance.enemyData.shield)
            {
                EnemyManager.instance.enemyData.shield -= shieldDmg;
            }
            else
            {
                    EnemyManager.instance.enemyData.currentHp -= dmg - EnemyManager.instance.enemyData.shield;
                    EnemyManager.instance.enemyData.shield -= shieldDmg;
            }
            return;
        }
        EnemyManager.instance.enemyData.currentHp -= dmg;
    }

    public void CreatePotion() 
    {
        System.Random rnd = new System.Random();
        int tokenNum = rnd.Next(1, 6);
        playerDeck.CreateCard(tokens[tokenNum]);
    }
}


