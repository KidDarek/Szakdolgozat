using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseSettings : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnMouseUpAsButton()
    {
        MenuManager.instance.menus[2].SetActive(false);
        MenuManager.instance.isMenuOpen = false;
    }
}
