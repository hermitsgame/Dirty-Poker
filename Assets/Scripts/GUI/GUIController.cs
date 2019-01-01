using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class GUIController : MonoBehaviour {

    [SerializeField] private Card card;
    [SerializeField] private DeckController deckController;

    [SerializeField] private GameObject playerHand;
    [SerializeField] private GameObject flop;
    [SerializeField] private GameObject Turn;
    [SerializeField] private GameObject River;

    void Start () {

        card.gameObject.SetActive(false);
    }

    private void Update() {
        // костыль исправить!!!
        if (deckController.GiveCardFlag == true) {
            CardTransformer(deckController.Cards);
            deckController.GiveCardFlag = false;
        }
    }

    void CardTransformer(Card[] cards) {

        for (int i = 0; i < cards.Length; i++) {

           /*
            if(card.GetComponent<Image>().sprite.name == "card-back" && card.gameObject != null) {
                Destroy(this.card.gameObject);
            }
            */

            switch(cards[i].CardLocation.LocationName) {
                case "Player Hand":
                    cards[i].CardLocation.OffsetX = -50.0f;
                    ChangeCardPosition(cards[i], playerHand, cards[i].CardLocation.OffsetX);
                    break;
                case "Flop":
                    cards[i].CardLocation.OffsetX = 80.0f;
                    cards[i].CardLocation.OffsetY = -110.0f;
                    ChangeCardPosition(cards[i], flop, cards[i].CardLocation.OffsetX, cards[i].CardLocation.OffsetY,
                        cards[i].CardLocation.ScaleMultipillerX, cards[i].CardLocation.ScaleMultipillerY);
                    break;
                case "Turn":
                    cards[i].CardLocation.OffsetX = 320.0f;
                    cards[i].CardLocation.OffsetY = -60.0f;
                    ChangeCardPosition(cards[i], Turn, cards[i].CardLocation.OffsetX, cards[i].CardLocation.OffsetY,
                        cards[i].CardLocation.ScaleMultipillerX, cards[i].CardLocation.ScaleMultipillerY);
                    break;
                case "River":
                    cards[i].CardLocation.OffsetX = 400.0f;
                    cards[i].CardLocation.OffsetY = -60.0f;
                    ChangeCardPosition(cards[i], River, cards[i].CardLocation.OffsetX, cards[i].CardLocation.OffsetY,
                        cards[i].CardLocation.ScaleMultipillerX, cards[i].CardLocation.ScaleMultipillerY);
                    break;

                default: Debug.Log("Unknown location!"); break;
            }
        }
    }

    void ChangeCardPosition(Card card, GameObject parent, float offsetX, float offsetY, float scaleMultiplierX, float scaleMultiplierY) {

        GameObjectUtility.SetParentAndAlign(card.gameObject, parent);

        float posX = (offsetX * card.CardsGiven) + card.transform.position.x;
        // тесты
        Debug.Log("Card " + card.Id + " CardsGIven " + card.CardsGiven + " PosX" + posX);
        float posY = offsetY + card.transform.position.y;
        card.gameObject.transform.position = new Vector3(posX, posY);
        card.gameObject.transform.localScale = new Vector3(scaleMultiplierX, scaleMultiplierY);
    }

    void ChangeCardPosition(Card card, GameObject parent, float offsetX) {

        if (card.CardsGiven == 1) {
            offsetX = -20.0f;
        }
        GameObjectUtility.SetParentAndAlign(card.gameObject, parent);
        float posX = (offsetX * card.CardsGiven) + this.card.transform.position.x;
        float posY = card.transform.position.y;
        card.gameObject.transform.position = new Vector3(posX, posY);
    }

}

