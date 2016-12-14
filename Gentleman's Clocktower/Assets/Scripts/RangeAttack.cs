using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class RangeAttack : MonoBehaviour {

	public GameObject bullet;
	public GameObject gunEnd;
	public float disappearDelay;
	public float firePower;
    public float timeBetweenShooting;
	private Transform gun;
    private int bulletCount;
	private float shownTime;
    private bool shooting;

	// Use this for initialization
	void Start () {
        gun = GetComponentInChildren<Transform>();
		gun.transform.localScale = new Vector3 (0f,0f,0f);
		shownTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(1) && !GentlemansSingleton.GetPlayer().GetAnimator().GetBool("Attacking"))
        {//right click
			shooting = true;
            showGun();
            pointGun();
            fireGun();
			GetComponent<AudioSource>().Play ();
		}

		if (Time.time - shownTime > disappearDelay && shooting) {
			shooting = false;
			gun.transform.localScale = new Vector3 (0f, 0f, 0f);//hide gun
			GentlemansSingleton.GetPlayer ().GetAnimator ().SetBool ("Attacking", false);
		}
	}

	void showGun(){
		gun.transform.localScale = new Vector3 (1f,1f,1f);
		GentlemansSingleton.GetPlayer().GetAnimator().SetBool("Attacking", true);
		if (Input.mousePosition.x > Screen.width / 2) {
			GentlemansSingleton.GetPlayer ().GetSpriteRenderer ().flipX = false;
		} else {
			GentlemansSingleton.GetPlayer ().GetSpriteRenderer ().flipX = true;
		}
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

    void fireGun()
    {
        GameObject firedBullet = (GameObject)Instantiate(bullet,
                        gunEnd.GetComponent<Transform>().position,
                        Quaternion.identity);
        firedBullet.GetComponent<Rigidbody2D>().AddForce(
            gunEnd.GetComponent<Transform>().up * firePower);
		Physics2D.IgnoreCollision (GetComponent<Collider2D> (), firedBullet.GetComponent<Collider2D> (), true);
    }
}