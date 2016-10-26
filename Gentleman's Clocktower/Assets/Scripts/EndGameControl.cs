using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class EndGameControl : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag.Equals("Player")){
			int scene = SceneManager.GetActiveScene ().buildIndex;
			SceneManager.LoadScene (scene, LoadSceneMode.Single);
		}
	}
}
