using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    ClassDataSo data;
    [SerializeField] GameObject healthPrefab;
    GameObject[] healts;
    // Start is called before the first frame update

    void Start()
    {
        data = GameManager.instance.heroData;
        print(data);
        healts = new GameObject[data.maxHp];
        CreateHealthPoints(data);
    }

    // Update is called once per frame
    void Update()
    {
        ReRenderHealthPoints();
    }

    void CreateHealthPoints(ClassDataSo data)
    {
        for (int i = 0; i < data.maxHp; i++)
        {
            GameObject health;
            if (i >= data.currentHp)
            {
                health = Instantiate(healthPrefab, transform);
                health.transform.GetComponent<SpriteRenderer>().color = Color.gray;
            }
            else
            {
                health = Instantiate(healthPrefab, transform);
                health.transform.GetComponent<SpriteRenderer>().color = Color.red;
            }
            healts[i] = health;
        }
    }

    void ReRenderHealthPoints()
    {
        for (int i = 0; i < data.maxHp; i++)
        {
            if (i >= data.currentHp)
            {
                healts[i].transform.GetComponent<SpriteRenderer>().color = Color.gray;
            }
            else
            {
                healts[i].transform.GetComponent<SpriteRenderer>().color = Color.red;
            }
        }
    }
}
