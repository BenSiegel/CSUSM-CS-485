using UnityEngine;
using System.Collections;

public class FinalBossScript : MonoBehaviour {

	public int health;
	public float speed;

	public GameObject movePoint1;
	public GameObject movePoint2;
	public GameObject movePoint3;
	public GameObject movePoint4;
	public GameObject movePoint5;

	private int actionCount;
	private Transform tf;
	private int laserAngle = 0;
	private LineRenderer line;

	void Start () {
		actionCount = 0;
		tf = GetComponent<Transform> ();
		line = GetComponent<LineRenderer> ();
	}

	void Update () {
		switch(actionCount){
		case 0:
			if (Summon ())
				actionCount++;
			break;
		case 1:
			if (MoveTo(movePoint1))
				actionCount++;
			break;
		case 2:
			if (MoveTo(movePoint2))
				actionCount++;
			break;
		case 3:
			if (Laser())
				actionCount++;
			break;
		case 4:
			if (MoveTo(movePoint1))
				actionCount++;
			break;
		case 5:
			if (MoveTo(movePoint3))
				actionCount++;
			break;
		case 6:
			if (MoveTo(movePoint4))
				actionCount++;
			break;
		case 7:
			if (MoveTo(movePoint5))
				actionCount++;
			break;
		case 8:
			if (Laser())
				actionCount++;
			break;
		case 9:
			if (MoveTo(movePoint4))
				actionCount++;
			break;
		case 10:
			if (MoveTo(movePoint3))
				actionCount++;
			break;
		default:
			actionCount = 0;
			break;
		}

	}

	bool MoveTo(GameObject point){
		Transform pointTf = point.GetComponent<Transform>();
		tf.Translate ((pointTf.position-tf.position).normalized * speed * Time.deltaTime);
		if ((pointTf.position - tf.position).magnitude < 1)
			return true;
		else
			return false;
	}

	bool Laser(){
		//charge up time here if needed later
		line.enabled = true;
		Vector2 origin;
		Vector2 direction = new Vector2(0.1f,-1f);
		if (tf.position.x < 0) {
			origin = new Vector2 (tf.position.x + 5f, tf.position.y);
		} else {
			origin = new Vector2 (tf.position.x - 5f, tf.position.y);
		}
		RaycastHit2D hit = Physics2D.Raycast (origin, Quaternion.AngleAxis(laserAngle, Vector2.up)*direction);//change tf positioning to the head
		int value = 5;
		Vector3[] pos = {origin, hit.point };
		line.SetPositions (pos);
		Debug.Log(Quaternion.AngleAxis(laserAngle, Vector2.up)*direction);
		Debug.Log("Hit: " + hit.point + " Angle: " + laserAngle);
		laserAngle++;
		if (laserAngle == 360) {
			laserAngle = 0;
			line.enabled = false;
			return true;
		} else
			return false;
	}

	bool Summon(){
		return true;
	}
}
