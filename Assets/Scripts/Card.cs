using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour {

    [SerializeField] private DeckController deck;

    private CardLocation cardLocation;

    private int id; // id карты
    private string suit; // масть карты
    private string rank; // ранк карты

    private int cardsGiven; // номер карты во время выдачи

    // свойства 
    public CardLocation CardLocation {
        get { return cardLocation; }
        set { cardLocation = value; }
    }
    public int Id {
        get { return id; }
    }
    public string Suit {
        get { return suit; }
    }
    public string Rank {
        get { return rank; }
    }
    public int CardsGiven {
        get { return cardsGiven; }
        set { cardsGiven = value; }
    }


    private void Awake() {
        cardLocation = this.gameObject.GetComponent<CardLocation>();
    }
    // задаем параметры карте:
    public void SetCard(int Id, Sprite image) {
        // задаем id
        id = Id;
        // задаем масть и ранг через имя спрайта
        suit = image.name.Split('_')[0];
        rank = image.name.Split('_')[1];
        // задаем картинку на карту
        GetComponent<Image>().sprite = image;
        // тесты
        Debug.Log("ID: " + id + " " + suit + " " + rank + " " + cardLocation.LocationName);
    }
}
