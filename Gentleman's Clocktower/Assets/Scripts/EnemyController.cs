using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D collision){
		Debug.Log ("Col");
		if (collision.gameObject.tag == "eDamage")
			DestroyObject(gameObject,0f);
	}
}
