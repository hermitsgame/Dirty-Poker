﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardLocation : MonoBehaviour {

    private string locationName = "Deck";

    private float offsetX;
    private float offsetY;

    private float scaleMultiplierX = 1.0f;
    private float scaleMultiplierY = 1.0f;

    // свойства
    public string LocationName {
        get { return locationName; }
        set { locationName = value; }
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
}
