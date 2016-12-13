using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float jump;
    public int health;
    public int EFly1Attack;
    public int EFly2Attack;
    public int EFly3Attack;
    public int EGround1Attack;
    public int EGround2Attack;
    public int MiniBossAttack;

    private Transform tm;
    private bool canJump;
    private bool isJumping;
    private float jumpToHight;
	private bool wall1;
	private bool wall2;

    Animator anim;
    Rigidbody2D rb;
    SpriteRenderer sr;

    float someScale;

    void Start()
    {
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
    }

    void Update()
    {
        if (isJumping)
        {
            transform.Translate(new Vector3(0f, 1f) * Time.deltaTime * speed);
            if (transform.position.y >= jumpToHight)
            {
                rb.isKinematic = false;
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
            sr.flipX = true;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            //sr.transform.localScale = new Vector2(someScale, transform.localScale.y);
            sr.flipX = false;
        }

        if (Input.GetKey(KeyCode.W) && canJump)
        {
			GetComponent<Rigidbody2D> ().isKinematic = true;
			jumpToHight = transform.position.y + jump;
			GetComponent<AudioSource>().Play ();
			canJump = false;
			isJumping = true;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Ground"))
        {
            canJump = true;
            anim.SetBool("Jumping", false);
        } else
        {
            anim.SetBool("Jumping", true);
        }
        if (col.gameObject.tag.Equals("EFly1"))
            health -= EFly1Attack;
        if (col.gameObject.tag.Equals("EFly2"))
            health -= EFly2Attack;
        if (col.gameObject.tag.Equals("EFly3"))
            health -= EFly3Attack;
        if (col.gameObject.tag.Equals("EGround1"))
            health -= EGround1Attack;
        if (col.gameObject.tag.Equals("EGround2"))
            health -= EGround2Attack;
        if (col.gameObject.tag.Equals("miniboss"))
            health -= MiniBossAttack;
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
}
