using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSlot : MonoBehaviour
{
    bool isSpaceOpen;
    // Start is called before the first frame update
    void Start()
    {
        isSpaceOpen = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsTouchingMouse(gameObject)
            && Input.GetMouseButtonUp(0)
            && MovementManager.instance.isCardDragged
            && GameManager.instance.IsCardPlayable(MovementManager.instance.selectedCard.GetComponent<Card>().data)
            && isSpaceOpen
            && MovementManager.instance.selectedCard.GetComponent<Card>().data.cardType == CardTypes.Equipment)
        {
            MovementManager.instance.selectedCard.transform.position = transform.position + new Vector3(0, 0, -1f);
            GameManager.instance.cardsOnBoard.Add(MovementManager.instance.selectedCard);
            MovementManager.instance.selectedCard.transform.rotation = Quaternion.Euler(0, 0, 0);
            MovementManager.instance.selectedCard.transform.GetComponent<CardAction>().PlayCard();
            GameManager.instance.SpendActionOrReaction();
            isSpaceOpen = false;
            MovementManager.instance.isCardDragged = false;
        }
    }
    bool IsTouchingMouse(GameObject g)
    {
        Vector2 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return g.GetComponent<Collider2D>().OverlapPoint(point);
    }
}