using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CardMovement : MonoBehaviour
{
    bool selected;
    int index;
    Transform parent;
    Quaternion defaultRotation;

    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent;
        index = transform.GetSiblingIndex();
        MovementManager.instance.SelectedCardParent = parent;
        defaultRotation = Quaternion.Euler(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (!selected && !GameManager.instance.cardsOnBoard.Contains(gameObject)
            || IsTouchingMouse(parent) && Input.GetMouseButtonUp(0) && !IsEquipment() && !IsAE() && !IsSummon())
        {
            MoveBack();
        }
        else if(!IsTouchingMouse(parent) && Input.GetMouseButtonUp(0) && !IsEquipment() && !IsAE() && !IsSummon())
        {
            if (GameManager.instance.IsCardPlayable(GetComponent<Card>().data))
            {
                transform.GetComponent<CardAction>().PlayCard();
                GameManager.instance.SpendActionOrReaction();
                if (IsArcaneSpellbookDown() 
                    && MovementManager.instance.selectedCard.GetComponent<Card>().data.cardType == CardTypes.Spell)
                {
                    GameManager.instance.playerDeck.PutCardInHand();
                }
                if (GameManager.instance.firstPotionOn 
                    && GetComponent<Card>().data.cardType == CardTypes.Token)
                {
                    GameManager.instance.playerDeck.CreateCard(GetComponent<Card>().data);
                    GameManager.instance.firstPotionOn = false;
                }
                if (gameObject.GetComponent<Card>().data.cardType != CardTypes.Token)
                {
                    GameManager.instance.playerDeck.AddCardToDeadDeck(GetComponent<Card>().data);
                }
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
        transform.SetSiblingIndex(index);
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
            index = transform.GetSiblingIndex();
            transform.SetParent(null);
            selected = true;
            MovementManager.instance.selectedCard = gameObject;
            MovementManager.instance.isCardSelected = selected;
            MovementManager.instance.isCardDragged = true;
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            Quaternion rotationValue = Quaternion.Euler(mousePosition.y - transform.position.y * 2, -(mousePosition.x - transform.position.x * 2), 0);

            transform.position = Vector3.Lerp(transform.position, mousePosition, Time.deltaTime * 15.0f);
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z -1.2f);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotationValue, Time.deltaTime * 15.0f);
        }

    }

    private void OnMouseEnter()
    {
        if (!MovementManager.instance.isCardDragged 
            && !GameManager.instance.cardsOnBoard.Contains(gameObject))
        {
            parent.transform.position = new Vector3(MovementManager.instance.baseCords[0],
                MovementManager.instance.baseCords[1] + 2.02f, MovementManager.instance.baseCords[2]);
        }
    }
    private void OnMouseExit()
    {
        if (!MovementManager.instance.isCardDragged
             && !GameManager.instance.cardsOnBoard.Contains(gameObject))
        {
            parent.transform.position = new Vector3(MovementManager.instance.baseCords[0],
               MovementManager.instance.baseCords[1], MovementManager.instance.baseCords[2]);
            index = transform.GetSiblingIndex();
            transform.SetParent(null);
            transform.SetParent(parent);
            transform.SetSiblingIndex(index);
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

    bool IsAE()
    {
        if (GetComponent<Card>().data.cardType == CardTypes.ArenaEffect)
        {
            return true;
        }
        return false;
    }

    bool IsSummon()
    {
        if (GetComponent<Card>().data.cardType == CardTypes.Summon)
        {
            return true;
        }
        return false;
    }

    bool IsArcaneSpellbookDown()
    {
        var cardsOnBoard = GameManager.instance.cardsOnBoard;
        bool isDown = false;
        for (int i = 0; i < cardsOnBoard.Count; i++)
        {
            if (cardsOnBoard[i].GetComponent<Card>().data.cardName == "Arcane Spellbook")
            {
                isDown = true;
            }
        }
        return isDown;
    }
}
