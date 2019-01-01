using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : MonoBehaviour, ICardsOpeations {

    [SerializeField] private Card card;
    [SerializeField] private DeckController deckController;

    private Card[] playerCards = new Card[2];
    public Card[] tradeCards = new Card[5];
    private int score;

    public Card[] PlayerCards {
        get { return playerCards; }
        set { playerCards = value; }
    }

    public Card[] TradeCards {
        get { return tradeCards; }
        set { tradeCards = value; }
    }

    public int Score {
        get { return score; }
        set { score = value; }
    }
    private void Start() {
        /*
        StartCoroutine(GetCards(deckController.Cards, "Player Hand"));*/
    }

    public IEnumerator GetCards(Card[] cards, string cardLocation) {
        yield return new WaitForSeconds(1);
        int j = 0;
        int k = 0;
        for (int i = 0; i < cards.Length; i++) {

            if (cards[i].CardLocation.LocationName == cardLocation) {

                playerCards[j] = cards[i];
                Debug.Log(playerCards[j].Rank + " " + j);
                j++;
            }
            else {
                tradeCards[k] = cards[i];
                Debug.Log(tradeCards[k].Rank + " " + k);
                k++;
            }
        }
       SumScore(playerCards[0].Score, playerCards[1].Score);
    }

    public void SumScore(int firstCard, int secondCard) {

        score = firstCard + secondCard;
        Debug.Log(score);
    }
}
