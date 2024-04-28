using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void OnMouseDown()
    {
        NextScene();
    }
    public void NextScene()
    {
        SceneManager.LoadScene(0);
    }
}

