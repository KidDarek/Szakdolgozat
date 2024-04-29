using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftMove : MonoBehaviour
{
    private void OnMouseUpAsButton()
    {
        NewCardManager.instance.cardnum -= 4;
        NewCardManager.instance.RenderCards();
    }
}
