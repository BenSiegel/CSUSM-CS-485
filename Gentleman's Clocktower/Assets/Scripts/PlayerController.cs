using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float jump;
	public int health;

    private Transform tm;
    private bool canJump = true;

    void Start()
    {
		health = 10;
		tm = GetComponent<Transform>();
    }

    void Update()
    {
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
            transform.Translate(Vector3.up * jump * Time.deltaTime);
            canJump = false;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Ground"))
            canJump = true;
        if (col.gameObject.tag.Equals("Enemy"))
            health--;        
    }
     
}