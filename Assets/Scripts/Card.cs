using System;
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

    private int score;

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
    public int Score {
        get { return score; }
        set { score = value; }
    }

    // аналог new CardLocation(); но для  MonoBehaviour
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
        // назначем карте очки согласно ее рангу
        setCardScore();
        // тесты
        Debug.Log("ID: " + id + " " + suit + " " + rank + " " + cardLocation.LocationName + " " + score);
    }
    // счетчик очков согласно рангам
    public void setCardScore() {

        if(rank != "jack" && rank != "queen" && rank != "king" && rank != "ace") {
            score = Convert.ToInt32(rank);
        }
        else {
            switch(rank) {
                case "jack": score = 11; break;
                case "queen": score = 12; break;
                case "king": score = 13; break;
                case "ace": score = 14; break;
            }
        }
    }
}
