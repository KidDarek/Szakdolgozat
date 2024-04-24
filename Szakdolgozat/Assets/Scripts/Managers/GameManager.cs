using System.Collections;
using System.Collections.Generic;
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
    [SerializeField] List<CardDataSo> Tokens;
    public bool tokenDmgOn;

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
                playerDeck.CreateToken(Tokens[0]);
            }
            if (cardsOnBoard[i].GetComponent<Card>().data.cardName == "Paladin Shield")
            {
                heroData.shield++;
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
}


