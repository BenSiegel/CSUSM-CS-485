using UnityEngine;
using System.Collections;

public class GolemMinibossScript : MonoBehaviour {

	public int health;

	enum Actions: int {Track=0, Jump, SlamUp, SlamDown, Charge};
	private int currentAction;
	private GameObject player;
	private Vector3 moveToPoint;
	private float actionTime;

	// Use this for initialization
	void Start () {
		currentAction = (int)Actions.Track;
		player = GameObject.FindGameObjectWithTag("Player");
		actionTime = Time.realtimeSinceStartup;
	}
	
	// Update is called once per frame
	void Update () {
		switch (currentAction) {
		case((int)Actions.Track):
			Track();
			break;
		case((int)Actions.Jump):
			break;
		case((int)Actions.SlamUp):
			break;
		case((int)Actions.SlamDown):
			break;
		}
	}

	void Track(){
		Transform tm = GetComponent<Transform> ();
		Transform playerTM = player.GetComponent<Transform> ();
		tm.Translate (new Vector3(playerTM.position.x - tm.position.x, 0f) * Time.deltaTime);
	}
}
