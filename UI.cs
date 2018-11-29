using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {

    public Player player;
    private Text UItext;
	// Use this for initialization
	void Start () {
        UItext = GetComponent<Text>();
    }
	
	// Update is called once per frame
    // Displays Diamonds
	void Update () {
        UItext.text = "Diamonds: " + player.diamonds;
	}
}
