using UnityEngine;
using System.Collections;

public class RangeAttack : MonoBehaviour {

	public GameObject bullet;
	public GameObject gunEnd;
	public float disappearDelay;
	public float firePower;
	private Transform gun;
	private float shownTime;

	// Use this for initialization
	void Start () {
		gun = GetComponentInChildren<Transform>();
		gun.transform.localScale = new Vector3 (0f,0f,0f);
		shownTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown (1)){//right click
			showGun();
			pointGun();
			fireGun();
		}
		if(Time.time - shownTime > disappearDelay)
			gun.transform.localScale = new Vector3 (0f,0f,0f);//hide gun
	}

	void showGun(){
		gun.transform.localScale = new Vector3 (1f,1f,1f);
		shownTime = Time.time;
	}

	void pointGun(){
		Vector3 mousePos = Input.mousePosition;
		Vector3 rotationObject = Camera.main.WorldToScreenPoint(gun.position);
		mousePos.x = mousePos.x - rotationObject.x;
		mousePos.y = mousePos.y - rotationObject.y;
		float angle = Mathf.Atan2 (mousePos.y, mousePos.x) * Mathf.Rad2Deg - 90f;
		gun.rotation = Quaternion.Euler (new Vector3 (0f, 0f, angle));
	}

	void fireGun(){
		GameObject firedBullet = (GameObject)Instantiate (bullet, 
			           gunEnd.GetComponent<Transform>().position, 
			           Quaternion.identity);
		firedBullet.GetComponent<Rigidbody2D>().AddForce(
			gunEnd.GetComponent<Transform>().up * firePower);
	}
}
