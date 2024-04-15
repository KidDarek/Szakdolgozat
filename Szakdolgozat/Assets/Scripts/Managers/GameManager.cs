using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public ClassDataSo heroData;
    public List<GameObject> cardsOnBoard;
    public PlayerDeck playerDeck;
    public bool isPlayerTurn;

    int startingAp = 3;
    void Awake()
    {
        instance = this;
        heroData.currentAp = startingAp;
        heroData.currentRap = heroData.maxRap;
        heroData.currentHp = heroData.maxHp;
        heroData.shield = 0;
        heroData.attackDmgBonus = 0;
        heroData.spellDmgBonus = 0;
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
}
