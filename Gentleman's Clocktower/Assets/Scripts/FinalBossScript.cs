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

	enum Actions: int {Float, Slam, Laser, Summon};
	private int actionCount;
	private Transform tf;

	void Start () {
		actionCount = 0;
		tf = GetComponent<Transform> ();
	}

	void Update () {
		switch(actionCount){
		case 0:
			if (MoveTo (movePoint1))
				actionCount++;
			break;
		case 1:
			if (MoveTo (movePoint2))
				actionCount++;
			break;
		case 2:
			if (MoveTo (movePoint1))
				actionCount++;
			break;
		case 3:
			if (MoveTo (movePoint3))
				actionCount++;
			break;
		case 4:
			if (MoveTo (movePoint4))
				actionCount++;
			break;
		case 5:
			if (MoveTo (movePoint5))
				actionCount++;
			break;
		case 6:
			if (MoveTo (movePoint4))
				actionCount++;
			break;
		case 7:
			if (MoveTo (movePoint3))
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
}
