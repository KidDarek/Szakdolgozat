using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finalize : MonoBehaviour
{
    private void OnMouseUpAsButton()
    {
        StaticData.hero.baseDeck.Add(NewCardManager.instance.chosenCard);
        StaticData.fightNumber++;
        NextScene();
    }

    public void NextScene()
    {
        SceneManager.LoadScene(1);
    }
}
