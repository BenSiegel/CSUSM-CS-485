using UnityEngine;
using System.Collections;

public class CrusherControler : MonoBehaviour {

	public float moveDistence;
	public float speed;

	public GameObject crusher1;
	public GameObject crusher2;
	public GameObject crusher3;
	public GameObject crusher4;
	public GameObject crusher5;
	public GameObject crusher6;
	public GameObject crusher7;
	public GameObject crusher8;

	public GameObject wall1;
	public GameObject wall2;
	public GameObject wall3;
	public GameObject wall4;
	public GameObject wall5;
	public GameObject wall6;

	private Transform tm1;
	private Transform tm2;

	private int moveSet;
	private float move;

	void Start () {
		moveSet = 0;
		tm1 = crusher1.GetComponent<Transform> ();
		tm2 = crusher2.GetComponent<Transform> ();
		move = tm1.position.x + moveDistence;
	}

	void Update () {
		switch (moveSet) {
		case 0:
			tm1.Translate (Vector3.right * speed * Time.deltaTime);
			tm2.Translate (Vector3.left * speed * Time.deltaTime);
			if (tm1.position.x >= move) {
				moveSet++;
				tm1 = crusher3.GetComponent<Transform> ();
				tm2 = crusher4.GetComponent<Transform> ();
				wall1.tag = "Ground";
				wall2.tag = "Ground";
			}
			break;
		case 1:
			tm1.Translate (Vector3.right * speed * Time.deltaTime);
			tm2.Translate (Vector3.left * speed * Time.deltaTime);
			if (tm1.position.x >= move) {
				moveSet++;
				tm1 = crusher5.GetComponent<Transform> ();
				tm2 = crusher6.GetComponent<Transform> ();
				wall3.tag = "Ground";
				wall4.tag = "Ground";
			}
			break;
		case 2:
			tm1.Translate (Vector3.right * speed * Time.deltaTime);
			tm2.Translate (Vector3.left * speed * Time.deltaTime);
			if (tm1.position.x >= move) {
				moveSet++;
				tm1 = crusher7.GetComponent<Transform> ();
				tm2 = crusher8.GetComponent<Transform> ();
				wall5.tag = "Ground";
				wall6.tag = "Ground";
			}
			break;
		case 3:
			tm1.Translate (Vector3.right * speed * Time.deltaTime);
			tm2.Translate (Vector3.left * speed * Time.deltaTime);
			if (tm1.position.x >= move) {
				moveSet++;
			}
			break;
		}
	}
}
