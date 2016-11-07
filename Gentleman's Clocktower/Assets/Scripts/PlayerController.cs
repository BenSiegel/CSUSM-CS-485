using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float jump;
	public int health;

    private Transform tm;
    private bool canJump;
	private bool isJumping;
	private float jumpToHight;

    void Start()
    {
		canJump = true;
		isJumping = false;
		health = 10;
		tm = GetComponent<Transform>();
		jumpToHight = 0f;
    }

    void Update()
    {
		if (isJumping) {
			transform.Translate (new Vector3 (0f, 1f) * Time.deltaTime * speed);
			if (transform.position.y >= jumpToHight) {
				GetComponent<Rigidbody2D> ().isKinematic = false;
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
			canJump = false;
			isJumping = true;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Ground"))
            canJump = true;
        if (col.gameObject.tag.Equals("EFly1"))
            health-=2;
        if (col.gameObject.tag.Equals("EFly2"))
            health-=4;
        if (col.gameObject.tag.Equals("EFly3"))
            health-=4;
        if (col.gameObject.tag.Equals("EGround1"))
            health-=1;
        if (col.gameObject.tag.Equals("EGround2"))
            health-=2;
    }
     
}