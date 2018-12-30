using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : MonoBehaviour, ICardsOpeations {

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

        StartCoroutine(GetCards(deckController.Cards, "Player Hand"));
    }

    public IEnumerator GetCards(Card[] cards, string cardLocation) {
        yield return new WaitForSeconds(1);
        int j = 0;
        for (int i = 0; i < cards.Length; i++) {

            if (cards[i].CardLocation.LocationName == cardLocation) {

                playerCards[j] = cards[i];
                Debug.Log(playerCards[j].Rank + " " + j);
                j++;
            }
        }
       SumScore(playerCards[0].Score, playerCards[1].Score);
    }

    public void SumScore(int firstCard, int secondCard) {

        score = firstCard + secondCard;
        Debug.Log(score);
    }
}
