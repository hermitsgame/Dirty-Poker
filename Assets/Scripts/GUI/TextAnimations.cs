using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextAnimations : MonoBehaviour {

    [SerializeField] private Text startLabel;
    [SerializeField] private UIController uiController;

    // Use this for initialization
    void Start () {
        StartCoroutine(textBlinking(startLabel, uiController.StartGameFlag));
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator textBlinking(Text text, bool startGameFlag) {

        while (startGameFlag != true) {
            text.text = "";
            yield return new WaitForSeconds(.5f);
            text.text = "Press \"SPACE\" button to start!";
            yield return new WaitForSeconds(.5f);
        }
    }
}
