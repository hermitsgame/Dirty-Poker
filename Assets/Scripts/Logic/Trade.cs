using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trade : MonoBehaviour, ICardsOpeations {

    [SerializeField] private Card card;
    [SerializeField] private DeckController deckController;

    private Card[] tradeCards = new Card[5];
    private int score;

    public Card[] TradeCards {
        get { return tradeCards; }
        set { tradeCards = value; }
    }

    public int Score {
        get { return score; }
        set { score = value; }
    }

    public IEnumerator GetCards(Card[] cards, string cardLocation) {
        throw new System.NotImplementedException();
    }

    public void SumScore(int firstCard, int secondCard) {
        throw new System.NotImplementedException();
    }
}
