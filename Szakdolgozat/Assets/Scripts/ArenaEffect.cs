using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaEffect : CardSlot
{
    bool isArenaOpen;
    GameObject arenaEffect;
    // Start is called before the first frame update
    void Start()
    {
        isArenaOpen = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsTouchingMouse(gameObject)
                && Input.GetMouseButtonUp(0)
                && MovementManager.instance.isCardDragged
                && GameManager.instance.IsCardPlayable(MovementManager.instance.selectedCard.GetComponent<Card>().data)
                && isArenaOpen
                && MovementManager.instance.selectedCard.GetComponent<Card>().data.cardType == CardTypes.ArenaEffect)
        {
            MovementManager.instance.selectedCard.transform.position = transform.position + new Vector3(0, 0, -1f);
            GameManager.instance.cardsOnBoard.Add(MovementManager.instance.selectedCard);
            arenaEffect = MovementManager.instance.selectedCard;
            MovementManager.instance.selectedCard.transform.rotation = Quaternion.Euler(0, 0, 0);
            MovementManager.instance.selectedCard.transform.GetComponent<CardAction>().PlayCard();
            GameManager.instance.SpendActionOrReaction();
            isArenaOpen = false;
            MovementManager.instance.isCardDragged = false;
        }
        else if (IsTouchingMouse(gameObject)
            && Input.GetMouseButtonUp(0)
            && MovementManager.instance.isCardDragged
            && GameManager.instance.IsCardPlayable(MovementManager.instance.selectedCard.GetComponent<Card>().data)
            && !isArenaOpen
            && MovementManager.instance.selectedCard.GetComponent<Card>().data.cardType == CardTypes.ArenaEffect)
        {
            ReplaceArena();
        }

        bool IsTouchingMouse(GameObject g)
        {
            Vector2 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            return g.GetComponent<Collider2D>().OverlapPoint(point);
        }

        void ReplaceArena()
        {
            for (int i = 0; i < GameManager.instance.cardsOnBoard.Count; i++)
            {
                if (arenaEffect != GameManager.instance.cardsOnBoard[i])
                {
                    return;
                }
                MovementManager.instance.selectedCard.transform.GetComponent<CardAction>().PlayCard();
                GameManager.instance.playerDeck.AddCardToDeadDeck
                    (GameManager.instance.cardsOnBoard[i].GetComponent<Card>().data);
                Destroy(GameManager.instance.cardsOnBoard[i]);
                GameManager.instance.cardsOnBoard.Remove(GameManager.instance.cardsOnBoard[i]);
                MovementManager.instance.selectedCard.transform.position = transform.position + new Vector3(0, 0, -1f);
                GameManager.instance.cardsOnBoard.Add(MovementManager.instance.selectedCard);
                arenaEffect = MovementManager.instance.selectedCard;
                MovementManager.instance.selectedCard.transform.rotation = Quaternion.Euler(0, 0, 0);
                GameManager.instance.SpendActionOrReaction();
                MovementManager.instance.isCardDragged = false;
            }
        }
    }
}