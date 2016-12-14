using UnityEngine;
using AssemblyCSharp;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jump;
    public int health;
	public float iFrameTime;
    public int EFly1Attack;
    public int EFly2Attack;
    public int EFly3Attack;
    public int EGround1Attack;
    public int EGround2Attack;
    public int MiniBossAttack;

    private Transform tm;
    public bool canJump;
    public bool isJumping;
    public float jumpToHight;
	private bool wall1;
	private bool wall2;

	private float timeToHit;

    private Animator anim;
    private Rigidbody2D rb;
	private SpriteRenderer sr;

    float someScale;

    void Start()
    {
		GentlemansSingleton.SetPlayer (this);
        canJump = true;
        isJumping = false;
		wall1 = false;
		wall2 = false;

        tm = GetComponent<Transform>();
        jumpToHight = 0f;

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        someScale = transform.localScale.x;

		timeToHit = Time.time;
    }

    void Update()
    {
        if(health <= 0)
        {
            isDead();
        }
        if (isJumping)
        {
            transform.Translate(new Vector3(0f, 1f) * Time.deltaTime * speed);
            if (transform.position.y >= jumpToHight)
            {
                isJumping = false;
            }
        }
		if (wall1 && wall2)//crushed in trap
			health = 0;
        WASD();
    }

    void WASD()
    {
        anim.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            //sr.transform.localScale = new Vector2(-someScale, transform.localScale.y);
			if (!anim.GetBool("Attacking"))
            	sr.flipX = true;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            //sr.transform.localScale = new Vector2(someScale, transform.localScale.y);
			if (!anim.GetBool("Attacking"))
            	sr.flipX = false;
        }

        if (Input.GetKey(KeyCode.W) && canJump)
        {
			jumpToHight = transform.position.y + jump;
			GetComponent<AudioSource>().Play ();
			canJump = false;
			isJumping = true;
			anim.SetBool("Jumping", true);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Ground"))
        {
			isJumping = false;
			canJump = true;
            anim.SetBool("Jumping", false);
        }
		if (timeToHit < Time.time) {
			if (col.gameObject.tag.Equals ("EFly1")) {
				health -= EFly1Attack;
				timeToHit = Time.time + iFrameTime;
			}
			if (col.gameObject.tag.Equals ("EFly2")) {
				health -= EFly2Attack;
				timeToHit = Time.time + iFrameTime;
			}
			if (col.gameObject.tag.Equals ("EFly3")) {
				health -= EFly3Attack;
				timeToHit = Time.time + iFrameTime;
			}
			if (col.gameObject.tag.Equals ("EGround1")) {
				health -= EGround1Attack;
				timeToHit = Time.time + iFrameTime;
			}
			if (col.gameObject.tag.Equals ("EGround2")) {
				health -= EGround2Attack;
				timeToHit = Time.time + iFrameTime;
			}
			if (col.gameObject.tag.Equals ("miniboss")) {
				health -= MiniBossAttack;
				timeToHit = Time.time + iFrameTime;
			}
		}
    }

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag.Equals ("Crush")) {
			wall1 = true;
		}
		if (col.gameObject.tag.Equals ("Crush1")) {
			wall2 = true;
		}
		if (wall1 && wall2) {
			health = 0;
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

	public Animator GetAnimator(){
		return anim;
	}

	public SpriteRenderer GetSpriteRenderer(){
		return sr;
	}

    void isDead()
    {
        Application.LoadLevel("GameOver");
    }
}
