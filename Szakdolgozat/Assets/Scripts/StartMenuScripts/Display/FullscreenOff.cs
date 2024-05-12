using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullscreenOff : MonoBehaviour
{
    private void OnMouseUpAsButton()
    {
        ScreenManager.instance.fullscreen = false;
        ScreenManager.instance.checksBool[4] = true;
        ScreenManager.instance.checksBool[3] = false;
        ScreenManager.instance.SetScreen();
    }
}
