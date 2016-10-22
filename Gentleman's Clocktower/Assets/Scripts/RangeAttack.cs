using UnityEngine;
using System.Collections;

public class RangeAttack : MonoBehaviour {

	public GameObject bullet;
	public float disappearDelay;
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
			Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			gun.transform.LookAt (mousePos);
			gun.transform.rotation.x = 0f;
			gun.transform.rotation.y = 0f;
			gun.transform.localScale = new Vector3 (1f,1f,1f);
			shownTime = Time.time;
		}
		if(Time.time - shownTime > disappearDelay)
			gun.transform.localScale = new Vector3 (0f,0f,0f);
	}
}
