using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    public static ScreenManager instance;
    public GameObject[] checks;
    public bool[] checksBool = {false, false, true, true, false};
    public int width;
    public int height;
    public bool fullscreen;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
        height = 1080;
        width = 1920;
        fullscreen = true;
        SetScreen();
    }

    public void SetScreen()
    {
        Screen.SetResolution(width, height, fullscreen);
        for (int i = 0; i < 5; i++)
        {
            checks[i].SetActive(checksBool[i]);
        }
    }
}
