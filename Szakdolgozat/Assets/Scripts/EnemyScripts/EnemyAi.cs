using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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
            if (data.currentHp < 5 && data.currentRap > 0)
            {
                data.currentHp += 2;
                data.currentRap -= 1;
                var card = transform.GetChild(i);
                Destroy(card.gameObject);
            }
            else if (data.currentHp >= 8 && data.currentRap > 0 && data.shield < 10)
            {
                data.shield += 1;
                data.currentRap -= 1;
                var card = transform.GetChild(i);
                Destroy(card.gameObject);
            }
            else if (data.currentAp != 0)
            {
                ShieldCheck(2);
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
            return;
        }
        GameManager.instance.heroData.currentHp -= dmg;
    }
}
