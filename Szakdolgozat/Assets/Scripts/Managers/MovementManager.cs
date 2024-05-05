using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    public static MovementManager instance;
    public GameObject selectedCard;
    public Transform SelectedCardParent;
    public bool isCardSelected;
    public bool isCardDragged;
    public float[] baseCords = new float[3];

    void Awake()
    {
        instance = this;
        baseCords[0] = SelectedCardParent.transform.position.x;
        baseCords[1] = SelectedCardParent.transform.position.y;
        baseCords[2] = SelectedCardParent.transform.position.z;
    }
}
