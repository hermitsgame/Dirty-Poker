using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    [SerializeField] Text startGameLabel;

    private bool startGameFlag;

    public bool StartGameFlag {
        get { return startGameFlag; }
        set { startGameFlag = value; }
    }

    private void Awake() {
        startGameFlag = false;
    }
    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        StartTheGame(startGameLabel);
    }

    void StartTheGame(Text text) {

        if (Input.GetKeyDown("space") && startGameFlag != true) {
            Destroy(text.gameObject);
            startGameFlag = true;
            Debug.Log("GAME STARTED!");
            this.enabled = false;
        }
    }
}
