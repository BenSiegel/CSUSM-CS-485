using UnityEngine;
using System.Collections;

public class SpawnGolemTriggerScript : MonoBehaviour {

	public GameObject golem;

	private bool spawnedGolem = false;

	void OnTriggerEnter2D(Collider2D collision){
		if(!spawnedGolem && collision.gameObject.tag.Equals("Player")){
			spawnedGolem = true;
			Transform tm = GetComponent<Transform>();
			Vector3 pos = new Vector3 (tm.position.x, tm.position.y+5);
			GameObject newGolem = (GameObject)Instantiate (golem, pos, Quaternion.identity);
		}
	}
}
