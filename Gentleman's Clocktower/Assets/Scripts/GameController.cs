using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

    private bool restart;
    private bool gameOver;

    public Text healthText;
    public Text timerText;
    public Text primaryAmmoText;
    public GUIText restartText;

	// Use this for initialization
	void Start ()
    {
        restart = true;
        gameOver = false;
        healthText.text = "";
        timerText.text = "";
        primaryAmmoText.text = "";
	}
	
	// Update is called once per frame
	void Update ()
    {

	}
}
