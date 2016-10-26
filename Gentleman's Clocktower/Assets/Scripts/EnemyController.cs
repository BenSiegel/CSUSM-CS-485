using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public GameObject briefcase;
	public float enemySpeed;
	public float diveDistence;

	enum Actions: int {Track=0, Dive, Float};
	private int currentState;
	private GameObject player;
	private Vector3 movePoint;
	// Use this for initialization
	void Start () {
		currentState = (int)Actions.Track;
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		switch (currentState) {
			case (int)Actions.Track:
				Track ();
				break;
			case (int)Actions.Dive:
				Dive ();
				break;
			case (int)Actions.Float:
				Float ();
				break;
		}
	}

	void Track(){
		Transform tm = GetComponent<Transform> ();
		Transform playerTM = player.GetComponent<Transform> ();
		tm.Translate ((playerTM.position - tm.position) * Time.deltaTime);
		if ((playerTM.position - tm.position).magnitude < diveDistence) {
			currentState = (int)Actions.Dive;
			movePoint = player.GetComponent<Transform> ().position;
		}
	}

	void Dive(){
		Transform tm = GetComponent<Transform> ();
		tm.Translate ((movePoint - tm.position) * Time.deltaTime * enemySpeed);
		if ((tm.position-movePoint).magnitude < 1f) {
			currentState = (int)Actions.Float;
			movePoint = tm.position + Vector3.up * diveDistence;
		}
	}

	void Float(){
		Transform tm = GetComponent<Transform> ();
		tm.Translate ((movePoint - tm.position) * Time.deltaTime);
		if ((tm.position-movePoint).magnitude < 1f)
			currentState = (int)Actions.Track;
	}

	void OnCollisionEnter2D(Collision2D collision){
		if(collision.gameObject.tag.Equals("eDamage")){
			DeadAction ();
		}
	}

	void OnTriggerEnter2D(Collider2D collision){
		if(collision.gameObject.tag.Equals("eDamage")){
			DeadAction ();
		}
	}

	void DeadAction(){
		Transform tm = GetComponent<Transform> ();
		Vector3 pos = new Vector3 (tm.position.x, tm.position.y, tm.position.z);
		GameObject briefcaseNew = (GameObject) Instantiate(briefcase, pos, Quaternion.identity);
		DestroyObject(gameObject,0f);
	}
}
