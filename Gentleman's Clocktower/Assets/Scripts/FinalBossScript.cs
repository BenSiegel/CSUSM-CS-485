using UnityEngine;
using System.Collections;

public class FinalBossScript : MonoBehaviour {

	public int health;
	public float speed;
	public float laserSpeed;
	public Vector2 headPos;
	public int bossLaserDamage;

	public GameObject movePoint1;
	public GameObject movePoint2;
	public GameObject movePoint3;
	public GameObject movePoint4;
	public GameObject movePoint5;

	private int actionCount;
	private Transform tf;
	private float laserAngle = 0f;
	private LineRenderer line;

	void Start () {
		actionCount = 0;
		tf = GetComponent<Transform> ();
		line = GetComponent<LineRenderer> ();
		line.enabled = false;
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
		line.enabled = true;
		Vector2 origin;
		float value;
		if (tf.position.x < 0f) {
			origin = new Vector2 (tf.position.x + headPos.x, tf.position.y+headPos.y);//set to head position
			value = laserAngle+1.5f;
		} else {
			origin = new Vector2 (tf.position.x - headPos.x, tf.position.y+headPos.y);//set to head position
			value = 1.5f - laserAngle;
		}
		Vector2 direction = new Vector2 (Mathf.Cos(Mathf.PI*value), Mathf.Sin(Mathf.PI*value));
		RaycastHit2D hit = Physics2D.Raycast (origin, direction);
		if (hit.collider.gameObject.tag.Equals ("Player")) {
			laserAngle = 2f;
			PlayerController player = hit.collider.gameObject.GetComponent<PlayerController>();
			player.health -= bossLaserDamage;
		}
		Vector3[] pos = {origin, hit.point};
		line.SetPositions (pos);
		laserAngle += laserSpeed;
		if (laserAngle > 0.5f) {
			laserAngle = 0f;
			line.enabled = false;
			return true;
		} else
			return false;
	}

	bool Summon(){
		return true;
	}
}
