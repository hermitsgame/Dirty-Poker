using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    [SerializeField] private Text startLabel;

    private bool startGameFlag = false;
	// Use this for initialization
	void Start () {
        StartCoroutine(textBlinking(startLabel));

    }
	
	// Update is called once per frame
	void Update () {
        StartTheGame(startLabel);
    }

    void StartTheGame(Text text) {

        if (Input.GetKeyDown("space") && startGameFlag != true) {
            Destroy(text.gameObject);
            startGameFlag = true;
            Debug.Log("GAME STARTED!");
        }
    }
    IEnumerator textBlinking(Text text) {

            while(startGameFlag != true) {
                text.text = "";
                yield return new WaitForSeconds(.5f);
                text.text = "Press \"SPACE\" button to start!";
                yield return new WaitForSeconds(.5f);
            }

    }
}
