using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurn : MonoBehaviour
{
    IEnumerator EnemyTurn()
    {
        //Wait for 2 seconds
        yield return new WaitForSeconds(2);


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
        GameManager.instance.heroData.attackDmgBonus -= GameManager.instance.tempAttackBonus[0];
        GameManager.instance.heroData.spellDmgBonus -= GameManager.instance.tempAttackBonus[1];
        GameManager.instance.ResetTempAttack();
        transform.GetComponent<SpriteRenderer>().color = Color.red;
        StartCoroutine(EnemyTurn());
    }

}
