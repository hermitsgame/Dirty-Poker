using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour {

    [SerializeField] private DeckController deck;

    
    private int id; // id карты
    private string suit; // масть карты
    private string rank; // ранк карты
    private string location = "Deck"; // местонахождение карты

    private int cardsGiven; // номер карты во время выдачи

    // свойства 

    public int Id {
        get { return id; }
    }
    public string Suit {
        get { return suit; }
    }
    public string Rank {
        get { return rank; }
    }
    public string Location {
        get { return location; }
        set { location = value; }
    }
    public int CardsGiven {
        get { return cardsGiven; }
        set { cardsGiven = value; }
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
        Debug.Log("ID: " + id + " " + suit + " " + rank + " " + location);
    }
}
