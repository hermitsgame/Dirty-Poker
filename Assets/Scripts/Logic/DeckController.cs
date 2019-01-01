using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckController : MonoBehaviour {

    [SerializeField] private Card card;
    [SerializeField] private UIController startTheGame;
    [SerializeField] private Sprite[] images = new Sprite[cardsNum];

    private Card[] cards;

    private static int cardsNum = 52; // число карт в колоде
    private static int cardsPerPlayer = 2; // число карт выдаваемое игроку
    private static int cardsOnFlop = 3; // число карт на флопе
    private static int cardsOnTurnAndRiver = 1; // число карт на флопе
    private static int startIndex = 0; // индекс последней выданое карты в колоде
    private static bool giveCardFlag = false; // флаг для проверки ли выдавались карты

    public bool GiveCardFlag {
        get { return giveCardFlag; }
        set { giveCardFlag = value; }
    }

    public Card[] Cards {
        get { return cards; }
    }

    private void Awake() {
    }
    private void Start() {

    }

    private void Update() {
        if (startTheGame.StartGameFlag == true) {
            int[] deck = new int[cardsNum];
            for (int i = 0; i < cardsNum; i++) {
                deck[i] = i;
            }
            // тасуем колоду
            deck = ShuffleDeck(deck);

            GiveCard(deck, card, cardsPerPlayer, "Player Hand");

            GiveCard(deck, card, cardsOnFlop,  "Flop");

            GiveCard(deck, card, cardsOnTurnAndRiver, "Turn");

            GiveCard(deck, card, cardsOnTurnAndRiver, "River");

            cards = (Card[])GameObject.FindObjectsOfType(typeof(Card));

            startTheGame.StartGameFlag = false;
        }
    }
    // метод для тасование колоды
    private int[] ShuffleDeck(int[] numbers) {

        int[] newArray = numbers.Clone() as int[];

        for (int i = 0; i < newArray.Length; i++) {
            // используем алгоритм тасования Фишера Йетса
            int tmp = newArray[i];
            int r = Random.Range(i, newArray.Length);
            newArray[i] = newArray[r];
            newArray[r] = tmp;
        }

        return newArray;

    }
   /* IEnumerator GiveCards() {

    }*/
    // выдать карту
    private void GiveCard(int[] deck, Card card, int cardsPerPlayer, string cardLocationName) {

        int cardsGiven = 0; // номер карты во время выдачи

        // проверяем ли мы можем еще выдавать карты из колоды
        if (startIndex == deck.Length - 1 && cardsPerPlayer > 1) {

            Debug.Log("Error! There are fewer cards in the deck than you need to give out! "
                + "Cards in the deck: " + (deck.Length - startIndex) + " Cards need to give out: " + cardsPerPlayer);
        }

        if (startIndex == deck.Length) {
            Debug.Log("Error! The deck is empty!");
        }

        // начинаем выдачу карту с последнего индекса в колоде
        for (int i = startIndex; i < deck.Length; i++) {

            card = Instantiate(card);
            card.gameObject.SetActive(true); // перенести в ГУИ
            card.CardLocation.LocationName = cardLocationName;

            int index = i;
            int id = deck[index];

            // задаем параметры для новой карты
            card.SetCard(id, images[id]);

            cardsGiven++;
            card.CardsGiven += cardsGiven;
            startIndex += 1;
            giveCardFlag = true;
            // если индекс последней выданой карте раве индексу кол-ва вадваемых карт - прекращаем выдачу!

            if (cardsGiven == cardsPerPlayer) break;
        }
        // возвращаем последний индекс входа в колоду
        // return startIndex + 1;
    }
}
