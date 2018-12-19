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

    public float offsetX = 0.0f;
    public float offsetY = 0.0f;
    public float scaleMultiplierX = 1.0f;
    public float scaleMultiplierY = 1.0f;

    public Card[] cards;

    void Start () {

        card.gameObject.SetActive(false);
    }

    private void Update() {

        if (deckController.GiveCardFlag == true) {
            cards = (Card[])GameObject.FindObjectsOfType(typeof(Card));
            CardTransformer(cards);
            deckController.GiveCardFlag = false;
        }
    }

    void CardTransformer(Card[] cards) {

        for (int i = 0; i < cards.Length; i++) {

            // пока так
            if(card.GetComponent<Image>().sprite.name == "card-back") {
                Destroy(this.card.gameObject);
            }

            switch(cards[i].Location) {
                case "Player Hand": ChangeCardPosition(cards[i], playerHand, offsetX); break;
                case "Flop": ChangeCardPosition(cards[i], flop, offsetX, offsetY, scaleMultiplierX, scaleMultiplierY); break;
                case "Turn": ChangeCardPosition(cards[i], Turn, offsetX, offsetY, scaleMultiplierX, scaleMultiplierY); break;
                case "River": ChangeCardPosition(cards[i], River, offsetX, offsetY, scaleMultiplierX, scaleMultiplierY); break;

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

        GameObjectUtility.SetParentAndAlign(card.gameObject, parent);
        float posX = (offsetX * card.CardsGiven) + card.transform.position.x;
        float posY = card.transform.position.y;
        card.gameObject.transform.position = new Vector3(posX, posY);
    }

}

