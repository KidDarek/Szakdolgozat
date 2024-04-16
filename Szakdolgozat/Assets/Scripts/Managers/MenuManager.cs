using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;
    public List<GameObject> menus;
    public bool isMenuOpen;

    private void Awake()
    {
        instance = this;
        isMenuOpen = false;
    }

}
