using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullscreenOff : MonoBehaviour
{
    private void OnMouseUpAsButton()
    {
        ScreenManager.instance.fullscreen = false;
        ScreenManager.instance.SetScreen();
    }
}
