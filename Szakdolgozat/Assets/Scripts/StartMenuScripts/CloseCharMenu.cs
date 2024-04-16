using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseCharMenu : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnMouseUpAsButton()
    {
        MenuManager.instance.menus[0].SetActive(false);
        MenuManager.instance.isMenuOpen = false;
    }
}
