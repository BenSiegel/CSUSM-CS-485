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
		if(collision.gameObject.tag.Equals("eDamage")){
			OnAction ();
		}
	}

	void OnTriggerEnter2D(Collider2D collision){
		if(collision.gameObject.tag.Equals("eDamage")){
			OnAction ();
		}
	}

	void OnAction(){
		DestroyObject(gameObject,0f);
	}
}
