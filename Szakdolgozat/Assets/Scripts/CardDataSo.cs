using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum CardTypes
{
    Spell, Equipment, ArenaEffect, Summon, Token
}

public enum DamageType
{
    Physical, Magic,None
}

[CreateAssetMenu(menuName = "CardData")]
public class CardDataSo : ScriptableObject
{

    public int hp;
    public int dmg;
    public int draws;
    public int cost;
    public bool isActionCost;
    public bool isHealing;
    public string cardName;
    public string description;
    public DamageType dmgType;
    public CardTypes cardType;
    public GameObject prefab;

    void Types()
    {
        switch (cardType)
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
