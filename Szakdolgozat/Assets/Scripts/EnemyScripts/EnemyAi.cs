using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    ClassDataSo data;
    [SerializeField] CardDataSo prefab;
    [SerializeField] Transform left;
    [SerializeField] Transform right;
    bool leftOpen;
    bool rightOpen;
    int boost;

    int cards = 5;
    void Start()
    {
        leftOpen = true;
        rightOpen = true;
        data = EnemyManager.instance.enemyData;
        for (int i = 0; i < cards; i++)
        {
            PutCardInHand();
        }
        boost = StaticData.fightNumber;
        data.maxHp += boost*5;
        data.maxAp += boost/3;
        data.maxRap += boost/3;
        cards += boost/3;
        data.currentHp = data.maxHp;
    }
    private void Update()
    {
        if (data.shield < 0)
        {
            data.shield = 0;
        }
    }

    public void PlayCard() 
    {
        for (int i = 0; i < cards; i++)
        {
            if (data.currentAp != 0 
                && GameManager.instance.heroData.currentHp < (1 + data.attackDmgBonus)* data.currentAp
                && GameManager.instance.heroData.shield < 3)
            {
                ShieldCheck(1 + data.attackDmgBonus);
                data.currentAp--;
                var card = transform.GetChild(i);
                Destroy(card.gameObject);
            }
            else if (data.currentHp < 10 && data.currentRap > 0)
            {
                data.currentHp += 1;
                data.currentRap -= 1;
                var card = transform.GetChild(i);
                Destroy(card.gameObject);
            }
            else if (data.currentHp >= 16 && data.currentRap > 1 && data.shield < data.maxHp)
            {
                data.shield += 2;
                data.currentRap -= 2;
                var card = transform.GetChild(i);
                Destroy(card.gameObject);
            }
            else if (data.currentAp > 1 && data.currentHp >16 && leftOpen && boost > 2)
            {
                data.attackDmgBonus += 2;
                data.currentAp -= 2;
                var card = transform.GetChild(i);
                Destroy(card.gameObject);
                var equip = Instantiate(prefab.prefab, left);
                equip.transform.localScale = new Vector3(1f, 1f, 0f);
                leftOpen = false;
            }
            else if (data.currentAp > 1 && data.currentHp > 16 && rightOpen && boost > 3)
            {
                data.attackDmgBonus += 2;
                data.currentAp -= 2;
                var card = transform.GetChild(i);
                Destroy(card.gameObject);
                var equip = Instantiate(prefab.prefab, right);
                equip.transform.localScale = new Vector3(1f, 1f, 0f);
                rightOpen = false;
            }
            else if (data.currentAp > 0)
            {
                ShieldCheck(1 + data.attackDmgBonus);
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
        data.currentAp = 2 + boost/3; ;
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
