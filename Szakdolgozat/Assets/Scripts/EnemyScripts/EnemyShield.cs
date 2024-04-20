using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShield : MonoBehaviour
{
    ClassDataSo data;
    [SerializeField] GameObject shieldPrefab;
    GameObject[] shields;
    // Start is called before the first frame update

    void Start()
    {
        data = EnemyManager.instance.enemyData;
        shields = new GameObject[data.maxHp];
        CreateShieldPointd(data);
    }

    // Update is called once per frame
    void Update()
    {
        ReRender();
    }

    void CreateShieldPointd(ClassDataSo data)
    {
        for (int i = 0; i < data.maxHp; i++)
        {
            GameObject shield;
            if (i < data.shield)
            {
                shield = Instantiate(shieldPrefab, transform);
            }
            else
            {
                shield = Instantiate(shieldPrefab, transform);
                shield.transform.GetComponent<SpriteRenderer>().color = Color.white;
            }
            shields[i] = shield;
        }
    }

    void ReRender() 
    {
        for (int i = 0; i < data.maxHp; i++)
        {
            if (i < data.shield)
            {
                shields[i].transform.GetComponent<SpriteRenderer>().color = Color.grey ;
            }
            else
            {
                shields[i].transform.GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
    }

}