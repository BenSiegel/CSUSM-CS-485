using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public GameObject briefcase;

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
		Transform tm = GetComponent<Transform> ();
		Vector3 pos = new Vector3 (tm.position.x, tm.position.y, tm.position.z);
		GameObject briefcaseNew = (GameObject) Instantiate(briefcase, pos, Quaternion.identity);
		DestroyObject(gameObject,0f);
	}
}
