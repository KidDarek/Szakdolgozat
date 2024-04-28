using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject playerHand;

    private void OnMouseDown()
    {
        pauseMenu.SetActive(false);
        playerHand.SetActive(true);
    }
}
