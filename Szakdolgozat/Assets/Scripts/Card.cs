using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public CardDataSo data;

    void Types()
    {
        switch (data.cardType)
        {
            case CardTypes.Spell:
                break;
            case CardTypes.Equipment:
                break;
            case CardTypes.ArenaEffect:
                break;
            case CardTypes.Summon:
                break;
            default:
                break;
        }
    }

}
