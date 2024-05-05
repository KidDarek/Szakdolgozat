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

    public void PlayCard() 
    {
        onCardPlayed?.Invoke();
        if (GameManager.instance.heroData.currentAp > GameManager.instance.heroData.maxAp 
            || GameManager.instance.heroData.currentHp > GameManager.instance.heroData.maxHp)
        {
            GameManager.instance.heroData.SetToMax();
        }
    }

    

}
