using UnityEngine;
using System.Collections;

public class GolemMinibossScript : MonoBehaviour {

	public int health;
	public float timeBetweenAttacks;
	public float chargeSpeed;
	public float chargeTime;
	public float jumpHight;

	enum Actions: int {Track=0, Jump, SlamDown, Charge};
	public int currentAction;
	private GameObject player;
	private Vector3 moveToPoint;
	private float actionTime;
	private bool chargeRight;
	private GameObject[] arms;

	// Use this for initialization
	void Start () {
		currentAction = (int)Actions.Track;
		player = GameObject.FindGameObjectWithTag("Player");
		actionTime = Time.time;
		chargeRight = false;
		moveToPoint = Vector3.zero;

	}
	
	// Update is called once per frame
	void Update () {
		switch (currentAction) {
		case((int)Actions.Track):
			Track();
			break;
		case((int)Actions.Jump):
			Jump ();
			break;
		case((int)Actions.SlamDown):
			SlamDown ();
			break;
		case((int)Actions.Charge):
			Charge ();
			break;
		}
	}

	void Track(){
		Transform tm = GetComponent<Transform> ();
		Transform playerTM = player.GetComponent<Transform> ();
		tm.Translate (new Vector3(playerTM.position.x - tm.position.x, 0f) * Time.deltaTime);
		if (Time.time-actionTime >= timeBetweenAttacks) {
			actionTime = Time.time;
			if (playerTM.position.y - tm.position.y < tm.lossyScale.y) {
				currentAction = (int)Actions.Charge;
				if (playerTM.position.x - tm.position.x > 0)
					chargeRight = true;
				else
					chargeRight = false;
			} else {
				currentAction = (int)Actions.Jump;
				moveToPoint = playerTM.position;
			}
		}
	}

	void Charge(){
		Transform tm = GetComponent<Transform> ();
		if (chargeRight)
			tm.Translate (new Vector3(1f,0f) * Time.deltaTime * chargeSpeed);
		else
			tm.Translate (new Vector3(-1f,0f) * Time.deltaTime * chargeSpeed);
		if (Time.time - actionTime >= chargeTime) {
			currentAction = (int)Actions.Track;
			actionTime = Time.time;
		}
	}

	void Jump(){
		Transform tm = GetComponent<Transform> ();
		Rigidbody2D rb = GetComponent<Rigidbody2D> ();
		rb.isKinematic = true;
		tm.Translate (new Vector3(0f, moveToPoint.y + jumpHight) * Time.deltaTime);
		if (moveToPoint.y + jumpHight <= tm.position.y) {
			rb.isKinematic = false;
			currentAction = (int)Actions.SlamDown;
			actionTime = Time.time;
		}
	}

	void SlamDown(){
		currentAction = (int)Actions.Track;
		actionTime = Time.time;
	}
}
