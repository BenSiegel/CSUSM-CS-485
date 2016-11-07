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

    void Start()
    {
        canJump = true;
        isJumping = false;
        //health = 10;
        tm = GetComponent<Transform>();
        jumpToHight = 0f;
    }

    void Update()
    {
        if (isJumping)
        {
            transform.Translate(new Vector3(0f, 1f) * Time.deltaTime * speed);
            if (transform.position.y >= jumpToHight)
            {
                GetComponent<Rigidbody2D>().isKinematic = false;
                isJumping = false;
            }
        }
        WASD();
    }

    void WASD()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
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
            canJump = true;
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

}