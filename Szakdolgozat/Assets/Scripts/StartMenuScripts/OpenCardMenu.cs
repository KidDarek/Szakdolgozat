using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCardMenu : MonoBehaviour
{
    bool isOtherMenuOpen;
    private void Start()
    {
        isOtherMenuOpen = MenuManager.instance.isMenuOpen;
        MenuManager.instance.menus[1].SetActive(false);
    }
    private void OnMouseUpAsButton()
    {
        if (MenuManager.instance.isMenuOpen)
        {
            return;
        }
        MenuManager.instance.menus[1].SetActive(true);
        MenuManager.instance.isMenuOpen = true;
    }


}
