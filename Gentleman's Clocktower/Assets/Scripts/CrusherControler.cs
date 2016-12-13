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
				//tm1 = crusher3.GetComponent<Transform> ();
				//tm2 = crusher4.GetComponent<Transform> ();
			}
			break;
		case 1:
			break;
		case 2:
			break;
		case 3:
			break;
		}
	}
}
