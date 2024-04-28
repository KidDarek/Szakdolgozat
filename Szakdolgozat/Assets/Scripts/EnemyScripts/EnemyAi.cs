using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    ClassDataSo data;
    [SerializeField] CardDataSo prefab;
    int cards = 5;
    void Start()
    {
        data = EnemyManager.instance.enemyData;
        for (int i = 0; i < cards; i++)
        {
            PutCardInHand();
        }
    }

    public void PlayCard() 
    {
        for (int i = 0; i < cards; i++)
        {
            if (data.currentHp < 7 && data.currentRap > 0)
            {
                data.currentHp += 2;
                data.currentRap -= 1;
                var card = transform.GetChild(i);
                Destroy(card.gameObject);
            }
            else if (data.currentHp >= 6 && data.currentRap > 0 && data.shield < 10)
            {
                data.shield += 1;
                data.currentRap -= 1;
                var card = transform.GetChild(i);
                Destroy(card.gameObject);
            }
            else if (data.currentAp != 0)
            {
                ShieldCheck(1);
                data.currentAp--;
                var card = transform.GetChild(i);
                Destroy(card.gameObject);
            }
        }

    }

    public void ResetEnemy()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            var card = transform.GetChild(i);
            Destroy(card.gameObject);
        }
        for (int i = 0; i < cards; i++)
        {
            PutCardInHand();
        }
        data.currentAp = 2;
        data.currentRap = data.maxRap;
    }

    public void PutCardInHand()
    {
        var data = prefab;
        var card = Instantiate(data.prefab, transform);
    }


    void ShieldCheck(int dmg)
    {
        if (GameManager.instance.heroData.shield != 0)
        {
            if (dmg< GameManager.instance.heroData.shield)
            {
                GameManager.instance.heroData.shield--;
            }
            else
            {
                GameManager.instance.heroData.currentHp -= dmg - GameManager.instance.heroData.shield;
                GameManager.instance.heroData.shield--;

            }
            //Paladin Arena effect
            var board = GameManager.instance.cardsOnBoard;
            for (int i = 0; i < board.Count; i++)
            {
                if (dmg > GameManager.instance.heroData.shield && board[i].GetComponent<Card>().data.cardName == "Mountain Stance")
                {
                    GameManager.instance.heroData.shield++;
                }
                // Ranger AE
                if (board[i].GetComponent<Card>().data.cardName == "Hunters Trap")
                {
                    GameManager.instance.DmgCheck(1);
                }

            }

            return;
        }
        GameManager.instance.heroData.currentHp -= dmg;
    }
}
