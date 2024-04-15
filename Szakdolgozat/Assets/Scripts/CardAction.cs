using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardAction : MonoBehaviour
{
    public delegate void ActionHandler();
    public ActionHandler onCardPlayed;
    CardDataSo data;
    // Start is called before the first frame update
    void Start()
    {
        data = GetComponent<Card>().data;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayCard() 
    {
        onCardPlayed?.Invoke();
    }


}
