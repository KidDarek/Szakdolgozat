using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftMoveMenu : MonoBehaviour
{
    private void OnMouseUpAsButton()
    {
        CardManager.instance.cardnum -= 4;
        CardManager.instance.RenderCards();
    }
}
