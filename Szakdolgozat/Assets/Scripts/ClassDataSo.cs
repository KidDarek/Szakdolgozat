using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Classes
{
    Warrior, Ranger, Necromancer,Paladin,Alchemist,Ninja,Druid,Mage
}

public enum WeaponTypes 
{
    Melee,Ranged,Magic,Summon
}

[CreateAssetMenu(menuName = "KlassData")]
public class ClassDataSo : ScriptableObject
{

    public int maxHp;
    public int currentHp;
    public int shield;
    public int maxAp;
    public int currentAp;
    public int apRegain;
    public int maxRap;
    public int currentRap;
    public int attackDmgBonus;
    public int spellDmgBonus;
    public Sprite sprite;
    public Classes characterKlass;
    public WeaponTypes weapon;
    public GameObject prefab;
    public List<CardDataSo> baseDeck;
    public List<CardDataSo> deck = new();


    public void RestoreAp()
    {
        currentAp += apRegain;
        SetToMax();
    }
    public void RestoreRap()
    {
        currentRap = maxRap;
    }
    public void RestoreHealth(int health)
    {
        currentHp += health;
        SetToMax();
    }
    public void SetToMax()
    {
        if (currentAp > maxAp)
        {
            currentAp = maxAp;
        }
        if (currentHp > maxHp)
        {
            currentHp = maxHp;
        }
        if (shield > maxHp)
        {
            shield = maxHp;
        }
    }
    public void Decker()
    {
        for (int i = 0; i < baseDeck.Count; i++)
        {
            deck.Add(baseDeck[i]);
        }
    }
}
