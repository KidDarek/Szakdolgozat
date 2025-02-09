using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSlot : MonoBehaviour
{
    bool isSpaceOpen;
    GameObject[] boardSlots = new GameObject[2];
    [SerializeField] GameObject hand;
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
            && IsSummonOrEquipment())
        {
            if (MovementManager.instance.selectedCard.GetComponent<Card>().data.cardName == "Weapon Throw")
            {
                return;
            }
            MovementManager.instance.selectedCard.transform.position = transform.position + new Vector3(0, 0, -1f);
            GameManager.instance.cardsOnBoard.Add(MovementManager.instance.selectedCard);
            LeftOrRightSlot(MovementManager.instance.selectedCard);
            MovementManager.instance.selectedCard.transform.rotation = Quaternion.Euler(0, 0, 0);
            MovementManager.instance.selectedCard.transform.GetComponent<CardAction>().PlayCard();
            GameManager.instance.SpendActionOrReaction();
            isSpaceOpen = false;
            MovementManager.instance.isCardDragged = false;
            hand.transform.position = new Vector3(MovementManager.instance.baseCords[0],
     MovementManager.instance.baseCords[1], MovementManager.instance.baseCords[2]);
        }
        else if (IsTouchingMouse(gameObject)
            && Input.GetMouseButtonUp(0)
            && MovementManager.instance.isCardDragged
            && GameManager.instance.IsCardPlayable(MovementManager.instance.selectedCard.GetComponent<Card>().data)
            && !isSpaceOpen
            && IsSummonOrEquipment())
        {
            ReplaceEquipment();
            hand.transform.position = new Vector3(MovementManager.instance.baseCords[0],
MovementManager.instance.baseCords[1], MovementManager.instance.baseCords[2]);
        }
    }
    bool IsTouchingMouse(GameObject g)
    {
        Vector2 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return g.GetComponent<Collider2D>().OverlapPoint(point);
    }

    bool IsSummonOrEquipment() 
    {
        bool isIt = false;
        if (MovementManager.instance.selectedCard.GetComponent<Card>().data.cardType == CardTypes.Equipment
            || MovementManager.instance.selectedCard.GetComponent<Card>().data.cardType == CardTypes.Summon)
        {
            isIt = true;
        }
        return isIt;
    }

    void LeftOrRightSlot(GameObject card)
    {
        if (card.transform.position.x < 0)
        {
            boardSlots[0] = card;
        }
        else
        {
            boardSlots[1] = card;
        }
    }

    void ReplaceEquipment()
    {
        for (int i = 0; i < GameManager.instance.cardsOnBoard.Count; i++)
        {
            if (boardSlots[0] == GameManager.instance.cardsOnBoard[i])
            {
                MovementManager.instance.selectedCard.transform.GetComponent<CardAction>().PlayCard();
                GameManager.instance.playerDeck.AddCardToDeadDeck
                    (GameManager.instance.cardsOnBoard[i].GetComponent<Card>().data);
                Destroy(GameManager.instance.cardsOnBoard[i]);
                RemoveEqupmentDmgBonus(GameManager.instance.cardsOnBoard[i]);
                GameManager.instance.cardsOnBoard[i] = MovementManager.instance.selectedCard;
                MovementManager.instance.selectedCard.transform.position = transform.position + new Vector3(0, 0, -1f);
                boardSlots[0] = MovementManager.instance.selectedCard;
                MovementManager.instance.selectedCard.transform.rotation = Quaternion.Euler(0, 0, 0);
                GameManager.instance.SpendActionOrReaction();
                MovementManager.instance.isCardDragged = false;

            }
            else if (boardSlots[1] == GameManager.instance.cardsOnBoard[i])
            {
                MovementManager.instance.selectedCard.transform.GetComponent<CardAction>().PlayCard();
                GameManager.instance.playerDeck.AddCardToDeadDeck
                    (GameManager.instance.cardsOnBoard[i].GetComponent<Card>().data);
                Destroy(GameManager.instance.cardsOnBoard[i]);
                RemoveEqupmentDmgBonus(GameManager.instance.cardsOnBoard[i]);
                GameManager.instance.cardsOnBoard[i] = MovementManager.instance.selectedCard;
                MovementManager.instance.selectedCard.transform.position = transform.position + new Vector3(0, 0, -1f);
                boardSlots[1] = MovementManager.instance.selectedCard;
                MovementManager.instance.selectedCard.transform.rotation = Quaternion.Euler(0, 0, 0);
                GameManager.instance.SpendActionOrReaction();
                MovementManager.instance.isCardDragged = false;

            }
        }
    }

    void RemoveEqupmentDmgBonus(GameObject card)
    {
        if (card.GetComponent<Card>().data.dmgType == DamageType.Physical)
        {
            GameManager.instance.heroData.attackDmgBonus -= card.GetComponent<Card>().data.dmg;
        }
        else if (card.GetComponent<Card>().data.dmgType == DamageType.Magic)
        {
            GameManager.instance.heroData.spellDmgBonus -= card.GetComponent<Card>().data.dmg;
        }
    }
}
