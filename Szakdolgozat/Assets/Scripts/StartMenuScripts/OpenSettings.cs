using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSettings : MonoBehaviour
{
    bool isOtherMenuOpen;
    private void Start()
    {
        isOtherMenuOpen = MenuManager.instance.isMenuOpen;
        MenuManager.instance.menus[2].SetActive(false);
    }
    private void OnMouseUpAsButton()
    {
        if (MenuManager.instance.isMenuOpen)
        {
            return;
        }
        MenuManager.instance.menus[2].SetActive(true);
        MenuManager.instance.isMenuOpen = true;
    }


}
