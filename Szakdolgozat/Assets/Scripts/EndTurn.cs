using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurn : MonoBehaviour
{
    [SerializeField] EnemyAi enemyAi;
    IEnumerator EnemyTurn()
    {
        //Wait for 2 seconds
        yield return new WaitForSeconds(1);

        enemyAi.PlayCard();

        GameManager.instance.isPlayerTurn = true;

        GameManager.instance.StartTurnEffect();

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
        enemyAi.ResetEnemy();
        GameManager.instance.EndTurnEffect();
        GameManager.instance.strikeCount = 0;
        transform.GetComponent<SpriteRenderer>().color = Color.red;
        StartCoroutine(EnemyTurn());
    }

}
