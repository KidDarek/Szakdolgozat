using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelector : MonoBehaviour
{
    [SerializeField] ClassDataSo klass;

    private void OnMouseDown()
    {
        StaticData.hero = klass;
        NextScene();
    }
    public void NextScene()
    {
        SceneManager.LoadScene(1);
    }
}
