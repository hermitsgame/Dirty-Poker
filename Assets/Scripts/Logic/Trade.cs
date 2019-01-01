using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trade : MonoBehaviour {

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

    private void Start() {

       // Debug.Log(deckController.Cards.Length);
    }
}
