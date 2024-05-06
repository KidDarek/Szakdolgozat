using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Size720 : MonoBehaviour
{
    private void OnMouseUpAsButton()
    {
        ScreenManager.instance.width = 720;
        ScreenManager.instance.height = 480;
        ScreenManager.instance.SetScreen();
    }
}
