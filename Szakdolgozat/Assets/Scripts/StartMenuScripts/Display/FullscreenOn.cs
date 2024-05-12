using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullscreenOn : MonoBehaviour
{
    private void OnMouseUpAsButton()
    {
        ScreenManager.instance.fullscreen = true;
        ScreenManager.instance.checksBool[4] = false;
        ScreenManager.instance.checksBool[3] = true;
        ScreenManager.instance.SetScreen();
    }
}
