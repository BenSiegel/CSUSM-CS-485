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
	public Text bossHealth;

    // Use this for initialization
    void Start()
    {
        restart = true;
        gameOver = false;
        healthText.text = "";
        timerText.text = "";
        //specialAmmoText.text = "";
        ttimer = 0;
		bossHealth.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        ttimer = (int)Time.time;
        timerText.text = "Timer: " + ttimer;
		GolemMinibossScript golem;
		PlayerController player;
		if(FindObjectOfType(typeof(GolemMinibossScript)) != null){
			golem = (GolemMinibossScript)FindObjectOfType (typeof(GolemMinibossScript));
			bossHealth.text = "Golem Health: " + golem.health;
		}else
			bossHealth.text = "";
		if(FindObjectOfType(typeof(PlayerController)) != null){
			player = (PlayerController)FindObjectOfType (typeof(PlayerController));
			healthText.text = "Health: " + player.health;
		}else
			healthText.text = "";
    }
}
