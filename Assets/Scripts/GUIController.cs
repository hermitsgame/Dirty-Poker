using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GUIController : MonoBehaviour {

    [SerializeField] private Card card;
    [SerializeField] private DeckController deckController;

    [SerializeField] private GameObject playerHand;
    [SerializeField] private GameObject flop;
    [SerializeField] private GameObject Turn;
    [SerializeField] private GameObject River;

    public Card[] cards;

    void Start () {

        card.gameObject.SetActive(false);
    }

    private void Update() {

        if (deckController.GiveCardFlag == true) {
            cards = (Card[])GameObject.FindObjectsOfType(typeof(Card));
            deckController.GiveCardFlag = false;
        }


    }

    void CardTransformer(Card[] cards) {

        for (int i = 0; i < cards.Length; i++) {

            switch(cards[i].Location) {
                case "Player Hand":
                    

                    cards[i].gameObject.transform.position = new Vector3();
                    cards[i].gameObject.transform.localScale = new Vector3();

                    break;
                   
            }
        }
    }

    void ChangeCardPosition(Card card, GameObject parent, float offsetX, float scaleMultiplierX, float scaleMultiplierY) {

        GameObjectUtility.SetParentAndAlign(card.gameObject, parent);
        float posX = (offsetX * card.CardsGiven) + card.transform.position.x;
        float posY = card.transform.position.y;
        card.gameObject.transform.position = new Vector3(posX, posY);
        card.gameObject.transform.localScale = new Vector3(scaleMultiplierX, scaleMultiplierY);

    }
}

