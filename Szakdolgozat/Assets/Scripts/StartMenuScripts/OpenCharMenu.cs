using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCharMenu : MonoBehaviour
{
    bool isOtherMenuOpen;
    private void Start()
    {
        isOtherMenuOpen = MenuManager.instance.isMenuOpen;
        MenuManager.instance.menus[0].SetActive(false);
    }
    private void OnMouseUpAsButton()
    {
        if (isOtherMenuOpen)
        {
            return;
        }
        MenuManager.instance.menus[0].SetActive(true);
        MenuManager.instance.isMenuOpen = true;
    }


}
