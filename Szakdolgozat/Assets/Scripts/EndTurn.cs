using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurn : MonoBehaviour
{
    IEnumerator EnemyTurn()
    {
        //Wait for 2 seconds
        yield return new WaitForSeconds(2);

        HitPlayer();

        GameManager.instance.isPlayerTurn = true;

        GameManager.instance.heroData.RestoreAp();
        GameManager.instance.heroData.RestoreRap();

        transform.GetComponent<SpriteRenderer>().color = Color.green;
    }
    // Start is called before the first frame update

    void Start()
    {
        GameManager.instance.isPlayerTurn = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseUpAsButton()
    {
        if (!GameManager.instance.isPlayerTurn)
        {
            return;
        }
        GameManager.instance.isPlayerTurn = false;
        transform.GetComponent<SpriteRenderer>().color = Color.red;
        StartCoroutine(EnemyTurn());
    }

    void HitPlayer() 
    {
        int dmg = 2;
        if (GameManager.instance.heroData.shield != 0)
        {
            if (dmg < GameManager.instance.heroData.shield)
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
