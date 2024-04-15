using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour
{
    ClassDataSo data;
    [SerializeField] GameObject actionPrefab;
    GameObject[] actions;
    // Start is called before the first frame update

    void Start()
    {
        data = GameManager.instance.heroData;
        actions = new GameObject[data.maxAp];
        CreateActionPoints(data);
    }

    // Update is called once per frame
    void Update()
    {
        ReRenderActionPoints();
    }

    void CreateActionPoints(ClassDataSo data) 
    {
        for (int i = 0; i < data.maxAp ; i++)
        {
            GameObject action;
            if (i >= data.currentAp)
            {
                action = Instantiate(actionPrefab, transform);
                action.transform.GetComponent<SpriteRenderer>().color = Color.gray;
            }
            else
            {
                action = Instantiate(actionPrefab, transform);
                action.transform.GetComponent<SpriteRenderer>().color = Color.green;
            }
            actions[i] = action;
        }
    }

    void ReRenderActionPoints() 
    {
        for (int i = 0; i < data.maxAp; i++)
        {
            if (i >= data.currentAp)
            {
                actions[i].transform.GetComponent<SpriteRenderer>().color = Color.gray;
            }
            else
            {
                actions[i].transform.GetComponent<SpriteRenderer>().color = Color.green;
            }
        }
    }
}
