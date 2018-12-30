using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICardsOpeations{

    IEnumerator GetCards(Card[] cards, string cardLocation);

    void SumScore(int firstCard, int secondCard);

}
