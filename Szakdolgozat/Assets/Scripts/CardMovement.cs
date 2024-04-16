using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CardMovement : MonoBehaviour
{
    bool selected;
    Transform parent;
    Quaternion defaultRotation;

    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent;
        MovementManager.instance.SelectedCardParent = parent;
        defaultRotation = Quaternion.Euler(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (!selected && !GameManager.instance.cardsOnBoard.Contains(gameObject) 
            || IsTouchingMouse(parent) && Input.GetMouseButtonUp(0) && !IsEquipment())
        {
            MoveBack();
        }
        else if(!IsTouchingMouse(parent) && Input.GetMouseButtonUp(0) && !IsEquipment())
        {
            if (GameManager.instance.IsCardPlayable(GetComponent<Card>().data))
            {
                transform.GetComponent<CardAction>().PlayCard();
                GameManager.instance.SpendActionOrReaction();
                GameManager.instance.playerDeck.AddCardToDeadDeck(GetComponent<Card>().data);
                Destroy(gameObject);
            }
            else
            {
                MoveBack();
            }

        }


        if (Input.GetMouseButtonUp(0))
        {
            selected = false;
            MovementManager.instance.isCardDragged = false;
        }

    }

    void MoveBack()
    {
        transform.SetParent(parent);
        MovementManager.instance.isCardSelected = false;
        transform.rotation = Quaternion.Lerp(transform.rotation, defaultRotation, Time.deltaTime * 10.0f);

    }

    void OnMouseDrag()
    {
        if (!GameManager.instance.isPlayerTurn)
        {
            return;
        }
        if (!GameManager.instance.cardsOnBoard.Contains(gameObject))
        {
            transform.SetParent(null);
            selected = true;
            MovementManager.instance.selectedCard = gameObject;
            MovementManager.instance.isCardSelected = selected;
            MovementManager.instance.isCardDragged = true;
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            Quaternion rotationValue = Quaternion.Euler(mousePosition.y - transform.position.y * 2, -(mousePosition.x - transform.position.x * 2), 0);

            transform.position = Vector3.Lerp(transform.position, mousePosition, Time.deltaTime * 15.0f);
            transform.position = new Vector3(transform.position.x, transform.position.y, -1.2f);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotationValue, Time.deltaTime * 15.0f);
        }
        
    }

    private void OnMouseEnter()
    {
        if (!MovementManager.instance.isCardSelected &&
            !GameManager.instance.cardsOnBoard.Contains(gameObject))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 2.0f, transform.position.z);
        }
    }
    private void OnMouseExit()
    {
        if (!MovementManager.instance.isCardSelected &&
             !GameManager.instance.cardsOnBoard.Contains(gameObject))
        {
            transform.SetParent(null);
            transform.SetParent(parent);
        }
    }

    bool IsTouchingMouse(Transform g)
    {
        Vector2 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return g.GetComponent<Collider2D>().OverlapPoint(point);
    }

    bool IsEquipment()
    {
        if (GetComponent<Card>().data.cardType == CardTypes.Equipment)
        {
            return true;
        }
        return false;
    }
}
