using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;

public class Size1920 : MonoBehaviour
{
    private void OnMouseUpAsButton()
    {
        ScreenManager.instance.width = 1920;
        ScreenManager.instance.height = 1080;
        ScreenManager.instance.checksBool[0] = false;
        ScreenManager.instance.checksBool[1] = false;
        ScreenManager.instance.checksBool[2] = true;
        ScreenManager.instance.SetScreen();
    }
}
