using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] private Card card;
    [SerializeField] private DeckController deckController;

    private Card[] playerCards = new Card[2];
    private int score;

    public Card[] PlayerCards {
        get { return playerCards; }
        set { playerCards = value; }
    }

    public int Score {
        get { return score; }
        set { score = value; }
    }
    private void Start() {

        StartCoroutine(GetCards(deckController.Cards));
    }

    IEnumerator GetCards(Card[] cards) {
        GetCards(deckController.Cards);
        yield return new WaitForSeconds(1);
        for (int i = 0; i < cards.Length; i++) {

            if (cards[i].CardLocation.LocationName == "Player Hand") {
                int j = 0;
                playerCards[j] = cards[i];
                Debug.Log(playerCards[j].Rank);
                j++;
            }
        }
    }
}
