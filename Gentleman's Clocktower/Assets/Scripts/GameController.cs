using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour
{

    private bool restart;
    private bool gameOver;
    private int ttimer;

    public Text healthText;
    public Text timerText;
    public Text specialAmmoText;
    public GUIText restartText;

    // Use this for initialization
    void Start()
    {
        restart = true;
        gameOver = false;
        //healthText.text = "";
        timerText.text = "";
        //specialAmmoText.text = "";
        ttimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ttimer = (int)Time.time;
        timerText.text = "Timer: " + ttimer;
    }
}
