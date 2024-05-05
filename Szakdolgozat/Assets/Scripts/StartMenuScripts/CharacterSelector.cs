using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelector : MonoBehaviour
{
    [SerializeField] ClassDataSo klass;

    private void OnMouseDown()
    {
        klass.deck.Clear();
        klass.Decker();
        StaticData.hero = klass;
        StaticData.fightNumber = 0;
        NextScene();
    }
    public void NextScene()
    {
        SceneManager.LoadScene(1);
    }
}
