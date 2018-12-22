using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardLocation : MonoBehaviour {

    private string name;

    private float offsetX;
    private float offsetY;

    private float scaleMultiplierX;
    private float scaleMultiplierY;

    private int cardsGiven;

    public string Name {
        get { return name; }
        set { name = value; }
    }
    public float OffsetX {
        get { return offsetX; }
        set { offsetX = value; }
    }
    public float OffsetY {
        get { return offsetY; }
        set { offsetY = value; }
    }
    public float ScaleMultipillerX {
        get { return scaleMultiplierX; }
        set { scaleMultiplierX = value; }
    }
    public float ScaleMultipillerY {
        get { return scaleMultiplierY; }
        set { scaleMultiplierY = value; }
    }
    public int CardsGiven {
        get { return cardsGiven; }
        set { cardsGiven = value; }
    }


}
