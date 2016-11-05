using UnityEngine;
using System.Collections;

public class GolemMinibossScript : MonoBehaviour {

	public int health;

	enum Actions: int {Track=0, Jump, Attack, SlamUp, SlamDown, Charge};
	private int currentAction;
	private GameObject player;
	private Vector3 moveToPoint;
	private float actionTime;

	// Use this for initialization
	void Start () {
		currentAction = (int)Actions.Track;
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
