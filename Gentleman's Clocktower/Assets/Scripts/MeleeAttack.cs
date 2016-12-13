using UnityEngine;
using AssemblyCSharp;
using System.Collections;

public class MeleeAttack : MonoBehaviour {

	public float speed;
	public float timeBetweenSwings;
	private bool turning;
	private bool right;
	private float spinTime;
	private Transform cane;

	void Start(){
		turning = false;
		right = false;
		spinTime = Time.time;

		cane = GetComponentInChildren<Transform> ();
		cane.transform.localScale = new Vector3 (0f,0f,0f);
	}

	void Update () {
		if (Input.GetMouseButtonDown (0) && turning == false && 
			!GentlemansSingleton.GetPlayer().GetAnimator().GetBool("Attacking") ) {//left click
			GentlemansSingleton.GetPlayer().GetAnimator().SetBool("Attacking", true);
			turning = true;
			cane.transform.localScale = new Vector3 (1f,1f,1f);
			GetComponent<AudioSource>().Play ();
			spinTime = Time.time;
			if (Input.mousePosition.x > Screen.width / 2) {
				right = true;
				GentlemansSingleton.GetPlayer ().GetSpriteRenderer ().flipX = false;
			} else {
				right = false;
				GentlemansSingleton.GetPlayer ().GetSpriteRenderer ().flipX = true;
			}
		}
		if (turning) {
			if (right)
				cane.Rotate (Vector3.back * speed * Time.deltaTime);
			else
				cane.Rotate (Vector3.forward * speed * Time.deltaTime);
			if (Time.time - spinTime > timeBetweenSwings) {
				GentlemansSingleton.GetPlayer().GetAnimator().SetBool("Attacking", false);
				turning = false;
				cane.transform.localScale = new Vector3 (0f,0f,0f);
				cane.rotation = Quaternion.identity;
			}
		}
	}
}
