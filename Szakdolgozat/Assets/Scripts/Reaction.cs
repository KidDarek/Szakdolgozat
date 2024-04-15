using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reaction : MonoBehaviour
{
    ClassDataSo data;
    [SerializeField] GameObject reactionPrefab;
    GameObject[] reactions;
    // Start is called before the first frame update

    void Start()
    {
        data = GameManager.instance.heroData;
        reactions = new GameObject[data.maxAp];
        CreateReactionPoints(data);
    }

    // Update is called once per frame
    void Update()
    {
        ReRenderReactionPoints();
    }

    void CreateReactionPoints(ClassDataSo data)
    {
        for (int i = 0; i < data.maxRap; i++)
        {
            GameObject reaction;
            if (i >= data.currentRap)
            {
                reaction = Instantiate(reactionPrefab, transform);
                reaction.transform.GetComponent<SpriteRenderer>().color = Color.gray;
            }
            else
            {
                reaction = Instantiate(reactionPrefab, transform);
                reaction.transform.GetComponent<SpriteRenderer>().color = Color.yellow;
            }
            reactions[i] = reaction;
        }
    }

    void ReRenderReactionPoints()
    {
        for (int i = 0; i < data.maxRap; i++)
        {
            if (i >= data.currentRap)
            {
                reactions[i].transform.GetComponent<SpriteRenderer>().color = Color.gray;
            }
            else
            {
                reactions[i].transform.GetComponent<SpriteRenderer>().color = Color.yellow;
            }
        }
    }
}
