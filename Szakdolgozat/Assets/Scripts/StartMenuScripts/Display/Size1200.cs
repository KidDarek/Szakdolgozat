using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Size1280 : MonoBehaviour
{
    private void OnMouseUpAsButton()
    {
        ScreenManager.instance.width = 1280;
        ScreenManager.instance.height = 720;
        ScreenManager.instance.checksBool[0] = false;
        ScreenManager.instance.checksBool[1] = true;
        ScreenManager.instance.checksBool[2] = false;
        ScreenManager.instance.SetScreen();
    }
}
