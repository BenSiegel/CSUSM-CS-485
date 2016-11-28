using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadNextLevelScript : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D collision){
		if(collision.gameObject.tag.Equals("Player")){
			SceneManager.LoadScene("LevelTwoTheTower", LoadSceneMode.Single);
		}
	}
}
