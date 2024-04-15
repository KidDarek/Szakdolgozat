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

    void Awake()
    {
        instance = this;
    }
}
