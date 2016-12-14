using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public GameObject briefcase;
    public GameObject meleeWeaponA;
    public GameObject rangeWeaponA;

    public int health;
    public int damage;
    public int armour;
    public int speed;

	public float diveDistence;

	enum Actions: int {Track=0, Dive, Float, Jump};
	private int currentState;
	private GameObject player;
	private Vector3 movePoint;
    private int randChance;
	private enum EnemyTypes: int{Fly, Ground};
	private int type;
	private float jumpHeight;
	private bool wall1;
	private bool wall2;
	private bool canJump;

	// Use this for initialization
	void Start () {
		currentState = (int)Actions.Track;
		player = GameObject.FindGameObjectWithTag("Player");
        randChance = 0;
		if (tag.Contains ("Fly"))
			type = (int)EnemyTypes.Fly;
		else
			type = (int)EnemyTypes.Ground;
		wall1 = false;
		wall2 = false;
		canJump = false;
	}
	
	// Update is called once per frame
	void Update () {
		switch (type) {
		case (int) EnemyTypes.Fly:
			FlyingUpdate ();
			break;
		case (int) EnemyTypes.Ground:
			GroundUpdate();
			break;
		}
	}

	void GroundUpdate(){
		switch (currentState) {
		case (int)Actions.Track:
			GroundTrack ();
			break;
		case (int)Actions.Jump:
			Jump ();
			break;
		}
	}

	void FlyingUpdate(){
		switch (currentState) {
		case (int)Actions.Track:
			FlyingTrack ();
			break;
		case (int)Actions.Dive:
			Dive ();
			break;
		case (int)Actions.Float:
			Float ();
			break;
		}
	}

	void GroundTrack(){
		Transform tm = GetComponent<Transform> ();
		Transform playerTM = player.GetComponent<Transform> ();
		tm.Translate (new Vector3(playerTM.position.x - tm.position.x, 0f).normalized * Time.deltaTime * speed);
		if (canJump && playerTM.position.y > tm.position.y + 1) {
			//GetComponent<Rigidbody2D> ().isKinematic = true;
			currentState = (int)Actions.Jump;
			jumpHeight = tm.position.y + 2;
			canJump = false;
		}
	}

	void Jump(){
		Transform tm = GetComponent<Transform> ();
		Transform playerTM = player.GetComponent<Transform> ();
		tm.Translate (Vector3.up*Time.deltaTime*speed*10);
		if (tm.position.y >= jumpHeight) {
			GetComponent<Rigidbody2D> ().isKinematic = false;
			currentState = (int)Actions.Track;
		}
	}

	void FlyingTrack()
    {
		Transform tm = GetComponent<Transform> ();
		Transform playerTM = player.GetComponent<Transform> ();
		tm.Translate ((playerTM.position - tm.position).normalized * Time.deltaTime * speed);
		if ((playerTM.position - tm.position).magnitude < diveDistence)
        {
			currentState = (int)Actions.Dive;
			movePoint = player.GetComponent<Transform> ().position;
		}
	}

	void Dive()
    {
		Transform tm = GetComponent<Transform> ();
		tm.Translate ((movePoint - tm.position).normalized * Time.deltaTime * speed);
		if ((tm.position-movePoint).magnitude < 1f)
        {
			currentState = (int)Actions.Float;
			movePoint = tm.position + Vector3.up * diveDistence;
		}
	}

	void Float()
    {
		Transform tm = GetComponent<Transform> ();
		tm.Translate ((movePoint - tm.position).normalized * Time.deltaTime * speed);
		if ((tm.position-movePoint).magnitude < 1f)
			currentState = (int)Actions.Track;
	}

	void OnCollisionEnter2D(Collision2D collision)
    {
		if(collision.gameObject.tag.Equals("eDamage"))
        {
            health--;
            if(health == 0)
            {
                DeadAction();
            }
        }
		if (collision.gameObject.tag.Equals ("Ground")) {
			canJump = true;
		}
	}

	void OnTriggerEnter2D(Collider2D col)
    {
		if(col.gameObject.tag.Equals("eDamage"))
        {
            health--;
            if (health <= 0)
            {
                DeadAction();
            }
        }
		if (col.gameObject.tag.Equals ("Crush")) {
			wall1 = true;
		}
		if (col.gameObject.tag.Equals ("Crush1")) {
			wall2 = true;
		}
		if (wall1 && wall2) {
			DeadAction ();
		}
	}

	void OnTriggerExit2D(Collider2D col){
		if (col.gameObject.tag.Equals ("Crush")) {
			wall1 = false;
		}
		if (col.gameObject.tag.Equals ("Crush1")) {
			wall2 = false;
		}
	}

	void DeadAction(){
		Transform tm = GetComponent<Transform> ();
		Vector3 pos = new Vector3 (tm.position.x, tm.position.y, tm.position.z);
		GameObject briefcaseNew = (GameObject) Instantiate(briefcase, pos, Quaternion.identity);
		GetComponent<AudioSource>().Play ();
        DestroyObject(gameObject,0f);
	}
}
