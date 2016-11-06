using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public GameObject briefcase;
    public GameObject meleeWeaponA;
    public GameObject meleeWeaponB;
    public GameObject meleeWeaponC;

    public GameObject rangeWeaponA;
    public GameObject rangeWeaponB;
    public GameObject rangeWeaponC;


    public int health;
    public int damage;
    public int armour;
    public int speed;

	public float diveDistence;

	enum Actions: int {Track=0, Dive, Float};
	private int currentState;
	private GameObject player;
	private Vector3 movePoint;
    private int randChance;
	// Use this for initialization
	void Start () {
		currentState = (int)Actions.Track;
		player = GameObject.FindGameObjectWithTag("Player");
        randChance = 0;
	}
	
	// Update is called once per frame
	void Update () {
		switch (currentState) {
			case (int)Actions.Track:
				Track ();
				break;
			case (int)Actions.Dive:
				Dive ();
				break;
			case (int)Actions.Float:
				Float ();
				break;
		}
	}

	void Track()
    {
		Transform tm = GetComponent<Transform> ();
		Transform playerTM = player.GetComponent<Transform> ();
		tm.Translate ((playerTM.position - tm.position) * Time.deltaTime * speed);
		if ((playerTM.position - tm.position).magnitude < diveDistence)
        {
			currentState = (int)Actions.Dive;
			movePoint = player.GetComponent<Transform> ().position;
		}
	}

	void Dive()
    {
		Transform tm = GetComponent<Transform> ();
		tm.Translate ((movePoint - tm.position) * Time.deltaTime * speed);
		if ((tm.position-movePoint).magnitude < 1f)
        {
			currentState = (int)Actions.Float;
			movePoint = tm.position + Vector3.up * diveDistence;
		}
	}

	void Float()
    {
		Transform tm = GetComponent<Transform> ();
		tm.Translate ((movePoint - tm.position) * Time.deltaTime * speed);
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
	}

	void OnTriggerEnter2D(Collider2D collision)
    {
		if(collision.gameObject.tag.Equals("eDamage"))
        {
            health--;
            if (health == 0)
            {
                DeadAction();
            }
        }
	}

	void DeadAction(){
		Transform tm = GetComponent<Transform> ();
		Vector3 pos = new Vector3 (tm.position.x, tm.position.y, tm.position.z);
		GameObject briefcaseNew = (GameObject) Instantiate(briefcase, pos, Quaternion.identity);

        var chanceForSpecWep = Random.Range(1, 100);
        if(chanceForSpecWep >= 1 && chanceForSpecWep <= 25)
        {
            var specialWeaponSpawn = Random.Range(1, 100);
            if (specialWeaponSpawn >= 1 && specialWeaponSpawn <= 50)
            {
                var smSpawn = Random.Range(1, 100);

                if (smSpawn >= 1 && smSpawn <= 50)
                {
                    GameObject specialWeaponNewA = (GameObject)Instantiate(meleeWeaponA, pos, Quaternion.identity);
                }

                else if (smSpawn >= 51 && smSpawn <= 81)
                {
                    GameObject specialWeaponNewB = (GameObject)Instantiate(meleeWeaponB, pos, Quaternion.identity);
                }

                else if (smSpawn >= 82 && smSpawn <= 100)
                {
                    GameObject specialWeaponNewC = (GameObject)Instantiate(meleeWeaponC, pos, Quaternion.identity);
                }
            }

            else if (specialWeaponSpawn >= 51 && specialWeaponSpawn <= 100)
            {
                var srSpawn = Random.Range(0, 100);

                if (srSpawn >= 0 && srSpawn <= 50)
                {
                    GameObject specialWeaponNewA = (GameObject)Instantiate(rangeWeaponA, pos, Quaternion.identity);
                }

                else if (srSpawn >= 51 && srSpawn <= 81)
                {
                    GameObject specialWeaponNewB = (GameObject)Instantiate(rangeWeaponB, pos, Quaternion.identity);
                }

                else if (srSpawn >= 82 && srSpawn <= 100)
                {
                    GameObject specialWeaponNewC = (GameObject)Instantiate(rangeWeaponC, pos, Quaternion.identity);
                }
            }
        }

        DestroyObject(gameObject,0f);
	}
}
