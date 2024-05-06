using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullscreenOn : MonoBehaviour
{
    private void OnMouseUpAsButton()
    {
        ScreenManager.instance.fullscreen = true;
        ScreenManager.instance.SetScreen();
    }
}
