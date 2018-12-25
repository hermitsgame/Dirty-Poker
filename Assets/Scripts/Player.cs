using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] private Card card;
    [SerializeField] private DeckController deckController;

    private Card[] cards;
    private int score;

    public Card[] Cards {
        get { return cards; }
        set { cards = value; }
    }

    public int Score {
        get { return score; }
        set { score = value; }
    }

    private void Update() {
        if(deckController.Cards[0] != null) {

            for (int i = 0; i < deckController.Cards.Length; i++) {
                if (deckController.Cards[i].CardLocation.LocationName == "Player Hand") {
                    cards[i] = deckController.Cards[i];
                    Debug.Log("Player has: " + cards[i].Id);
                }
            }
        }

    }
}
