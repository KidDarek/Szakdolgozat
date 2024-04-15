using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGameArena : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene(1);
    }

    private void OnMouseDown()
    {
        NextScene();
    }
}
