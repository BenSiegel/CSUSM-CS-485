using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelReset : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.R)){
			int scene = SceneManager.GetActiveScene ().buildIndex;
			SceneManager.LoadScene (scene, LoadSceneMode.Single);
		}
	}
}
