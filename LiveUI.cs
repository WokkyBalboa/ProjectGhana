using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LiveUI : MonoBehaviour {

    public Player player;
    private Text UItext;
    // Use this for initialization
    void Start()
    {
        UItext = GetComponent<Text>();
    }

    // Update is called once per frame
    //Displays player lives
    void Update()
    {
        UItext.text = "Lives: " + player.lives;
    }
}

