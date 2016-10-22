using UnityEngine;
using System.Collections;

public class RangeAttack : MonoBehaviour {

	public GameObject bullet;
	public float disappearDelay;
	public float zValue;
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
			gun.transform.localScale = new Vector3 (1f,1f,1f);
			shownTime = Time.time;
			Vector3 mousePos = Input.mousePosition;
			mousePos.z = Camera.main.transform.position.z * -1;//try -1 here if it doesn't work
			Vector3 rotationObject = Camera.main.WorldToScreenPoint(gun.position);
			mousePos.x = mousePos.x - rotationObject.x;
			mousePos.y = mousePos.y - rotationObject.y;
			float angle = Mathf.Atan2 (mousePos.y, mousePos.x) * Mathf.Rad2Deg - 90f;
			gun.rotation = Quaternion.Euler (new Vector3 (0f, 0f, angle));
		}
		if(Time.time - shownTime > disappearDelay)
			gun.transform.localScale = new Vector3 (0f,0f,0f);
	}
}
