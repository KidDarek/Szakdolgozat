using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    ClassDataSo data;

    // Start is called before the first frame update
    void Start()
    {
        data = GameManager.instance.heroData;
        transform.GetComponent<SpriteRenderer>().sprite = data.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
